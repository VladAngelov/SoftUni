import { Injectable } from '@angular/core';
import { AngularFireDatabase, AngularFireList } from '@angular/fire/database';
import { Post } from '../models/post.model';
import { IBasePost } from '../shared/interfaces';

@Injectable()
export class ProjectService {

  projects: IBasePost[] = [];
  allProjects: AngularFireList<any>;

  constructor(private database: AngularFireDatabase) {
    this.allProjects = this.database.list('projects');
  }

  loadAllProjects(): IBasePost[] {
    this.projects = [];
    this.allProjects.snapshotChanges()
      .subscribe(projects => {
        projects.forEach(project => {
          let p = new Post();
          p._id = project.key;
          p.title = project.payload.val().title;
          p.content = project.payload.val().content;
          p.created_at = project.payload.val().createdAt;
          this.projects.push(p);
        });
      });
    return this.projects;
  }

  createProject(title: string, content: string, createdAt: string) {
    this.allProjects.push({ title: title, content: content, created_at: createdAt });
  }

  updateProject(key: string, title: string, content: string) {
    this.allProjects.update(key, { title: title, content: content });
  }

  deleteProject(key: string) {
    this.allProjects.remove(key);
  }

  loadProjectById(id: string): any {
    let project = new Post;
    let p = this.projects.find(x => x._id === id);

    project._id = p._id;
    project.content = p.content;
    project.title = p.title;
    project.created_at = p.created_at;

    return project;
  }
}
