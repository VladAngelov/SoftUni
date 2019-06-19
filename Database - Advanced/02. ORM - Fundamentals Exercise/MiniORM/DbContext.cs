namespace MiniORM
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Reflection;

    public abstract class DbContext
    {
        private readonly DatabaseConnection connection;

        private readonly Dictionary<Type, PropertyInfo> dbSetProperties;

        internal static readonly Type[] AllowedSqlTypes =
        {
            typeof(bool),
            typeof(string),
            typeof(int),
            typeof(uint),
            typeof(DateTime),
            typeof(decimal),
            typeof(double),
            typeof(long),
            typeof(ulong)
        };

        protected DbContext(string connectionString)
        {
            this.connection = new DatabaseConnection(connectionString);

            this.dbSetProperties = this.DiscoverSets();

            using (new ConnectionManager(connection))
            {
                this.InitializeDbSets();
            }

            this.MapAllRelations();
        }

        private void MapAllRelations()
        {
            foreach (KeyValuePair<Type, PropertyInfo> dbSetProperty in dbSetProperties)
            {
                Type dbSetType = dbSetProperty.Key;

                MethodInfo mapRelations = typeof(DbContext)
                    .GetMethod("MapRelations", BindingFlags.Instance | BindingFlags.NonPublic)
                    .MakeGenericMethod(dbSetType);

                object dbSet = dbSetProperty.Value.GetValue(this);

                mapRelations.Invoke(this, new object[] { dbSet });
            }
        }

        private void MapRelations<TEntity>(DbSet<TEntity> dbSet)
        where TEntity : class, new()
        {
            var entityType = typeof(TEntity);

            MapNavigationProperties(dbSet);

            var collections = entityType
                .GetProperties()
                .Where(p =>
                    p.GetType().IsGenericType &&
                    p.GetType().GetGenericTypeDefinition() == typeof(ICollection<>))
                .ToArray();

            foreach (var collection in collections)
            {
                var collectionType = collection.GetType().GetGenericArguments().First();

                var mapCollection = typeof(DbContext)
                    .GetMethod("MapCollection", BindingFlags.Instance | BindingFlags.NonPublic)
                    .MakeGenericMethod(entityType, collectionType);

                mapCollection.Invoke(this, new object[] { dbSet, collectionType });
            }
        }

        private void MapCollection<TDbSet, TCollection>(DbSet<TDbSet> dbSet, PropertyInfo collectionProperty)
        where TDbSet : class, new() where TCollection : class, new()
        {
            var entityType = typeof(TDbSet);
            var collectionType = typeof(TCollection);

            var primaryKeys = collectionType.GetProperties()
                .Where(p => p.HasAttribute<KeyAttribute>())
                .ToArray();

            var primaryKey = primaryKeys.First();
            var foreignKey = entityType.GetProperties()
                .First(pi => pi.HasAttribute<KeyAttribute>());

            bool isManyToMany = primaryKeys.Length >= 2;

            if (isManyToMany)
            {
                primaryKey = collectionType.GetProperties()
                    .First(pi =>
                        collectionType
                            .GetProperty(pi.GetCustomAttribute<ForeignKeyAttribute>().Name)
                    .PropertyType == entityType);

                var navigationDbSet = (DbSet<TCollection>)this.dbSetProperties[collectionType].GetValue(this);

                foreach (var entity in dbSet)
                {
                    var primaryKeyValue = foreignKey.GetValue(entity);

                    var navigationEntities = navigationDbSet
                        .Where(navigationEntity =>
                            primaryKey.GetValue(navigationEntity).Equals(primaryKeyValue))
                        .ToArray();

                    ReflectionHelper.ReplaceBackingField
                        (entity, collectionProperty.Name, navigationEntities);
                }
            }
        }

        private void MapNavigationProperties<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            Type entityType = typeof(TEntity);

            PropertyInfo[] foreignKeys = entityType.GetProperties()
                .Where(p => p.HasAttribute<ForeignKeyAttribute>())
                .ToArray();

            foreach (PropertyInfo foreignKey in foreignKeys)
            {
                var navigationPropertyName =
                    foreignKey.GetCustomAttribute<ForeignKeyAttribute>().Name;

                var navigationProperty =
                    entityType.GetProperty(navigationPropertyName);

                var navigationDbSet =
                    this.dbSetProperties[navigationProperty.PropertyType]
                        .GetValue(this);

                var navigationPrimaryKey = navigationProperty
                    .PropertyType
                    .GetProperties()
                    .First(p => p.HasAttribute<KeyAttribute>());

                foreach (TEntity entity in dbSet)
                {
                    object foreignKeyValue = foreignKey.GetValue(entity);

                    var navigationPropertyValue = ((IEnumerable<object>)navigationDbSet)
                        .First(currentNavigationProperty =>
                            navigationPrimaryKey
                                .GetValue(currentNavigationProperty)
                                .Equals(foreignKeyValue));

                    navigationProperty.SetValue(entity, navigationPropertyValue);
                }
            }
        }

        private void InitializeDbSets()
        {
            foreach (KeyValuePair<Type, PropertyInfo> dbSetProperty in this.dbSetProperties)
            {
                Type dbSetType = dbSetProperty.Key;
                PropertyInfo dbSetPropertyType = dbSetProperty.Value;

                MethodInfo populateDbSetGeneric = typeof(DbContext)
                    .GetMethod("PopulateDbSet", BindingFlags.NonPublic | BindingFlags.Instance)
                    .MakeGenericMethod(dbSetType);

                populateDbSetGeneric.Invoke(this, new object[] { dbSetPropertyType });
            }
        }

        private void PopulateDbSet<TEntity>(PropertyInfo dbSet)
        where TEntity : class, new()
        {
            IEnumerable<TEntity> tableEntities = LoadTableEntities<TEntity>();

            DbSet<TEntity> dbSetInstance = new DbSet<TEntity>(tableEntities);

            ReflectionHelper.ReplaceBackingField(this, dbSet.Name, dbSetInstance);
        }

        private IEnumerable<TEntity> LoadTableEntities<TEntity>()
        where TEntity : class
        {
            var table = typeof(TEntity);
            var columns = GetEntityColumnNames(table);
            var tableName = GetTableName(table);
            var fetchedRows = this.connection.FetchResultSet<TEntity>(tableName, columns).ToArray();

            return fetchedRows;
        }

        private string GetEntityColumnNames(Type tableType)
        {
            var tableName = ((TableAttribute))
        }

        private Dictionary<Type, PropertyInfo> DiscoverSets()
        {


        }

        public void SaveChanges()
        {
            var dbSets = this.dbSetProperties
                .Select(p => p.Value.GetValue(this))
                .ToArray();

            foreach (IEnumerable<object> dbSet in dbSets)
            {
                var invalidEntities = dbSet.Where(x => !IsObjectValid(x)).ToArray();

                if (invalidEntities.Any())
                {
                    throw new InvalidOperationException
                        ($"{invalidEntities.Length } Invalid Entities found in { dbSet.GetType().Name}!");
                }
            }

            using (new ConnectionManager(this.connection))
            {
                using (var transaction = this.connection.StartTransaction())
                {
                    foreach (var dbSet in dbSets)
                    {
                        var dbSetType = dbSet.GetType().GetGenericArguments().First();

                        var persistMehod = typeof(DbContext)
                            .GetMethod("Persist", BindingFlags.NonPublic | BindingFlags.Instance)
                            .MakeGenericMethod(dbSetType);

                        try
                        {
                            persistMehod.Invoke(this, new object[] { dbSet });
                        }
                        catch (TargetInvocationException tie)
                        {
                            throw tie.InnerException;
                        }
                        catch (InvalidOperationException)
                        {
                            transaction.Rollback();
                            throw;
                        }
                        catch (SqlException)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }

                    transaction.Commit();
                }
            }
        }

        private void Persist<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            var tableName = GetTableName(typeof(TEntity));

            var columns = this.connection.FetchColumnNames(tableName).ToArray();

            if (dbSet.ChangeTracker.Added.Any())
            {
                this.connection.InsertEntities(dbSet.ChangeTracker.Added, tableName, columns);
            }

            if (dbSet.ChangeTracker.Removed.Any())
            {
                this.connection.DeleteEntities(dbSet.ChangeTracker.Removed, tableName, columns);
            }

            var modifiedEntities = dbSet.ChangeTracker.GetModifiedEntities(dbSet).ToArray();

            if (modifiedEntities.Any())
            {
                this.connection.UpdateEntities(modifiedEntities, tableName, columns);
            }
        }

        private string GetTableName(Type type)
        {
            throw new NotImplementedException();
        }

        private bool IsObjectValid(object e)
        {
            var validationContext = new ValidationContext(e);
            var validationErrors = new List<ValidationResult>();

            var validationResult =
                Validator.TryValidateObject(
                    e, validationContext,
                    validationErrors, validateAllProperties: true);

            return validationResult;
        }
    }
}