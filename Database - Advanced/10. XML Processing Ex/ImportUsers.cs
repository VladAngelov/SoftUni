public static string ImportUsers(ProductShopContext context, string inputXml)
{
	XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportUsersDto[]), new XmlRootAttribute("User"));
	
	var usersDto = (ImportUsersDto[])xmlSerializer.Deserialize(new StringReader(inputXml));
	
	var users = new List<User>();
	
	foreach(var userDto in usersDto)
	{
		var user Mapper.Map<User>(userDto);
		users.Add(user);
	}
	
	context.Users.AddRange(users);
	context.SaveChanges();
	
	return $"Successfully imported {users.Count}";
}