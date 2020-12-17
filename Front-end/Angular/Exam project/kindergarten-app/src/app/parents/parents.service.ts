import { Injectable } from "@angular/core";
import { AngularFireDatabase, AngularFireList } from "@angular/fire/database";
import { Post } from "../models/post.model";
import { IBasePost } from "../shared/interfaces";

@Injectable()
export class ParentsService {

    posts: IBasePost[] = [];
    allPosts: AngularFireList<any>;

    constructor(private database: AngularFireDatabase) {
        this.allPosts = this.database.list('parents');
    }

    loadAllProjects(): IBasePost[] {
        this.posts = [];
        this.allPosts.snapshotChanges()
            .subscribe(projects => {
                projects.forEach(project => {
                    let p = new Post();
                    p._id = project.key;
                    p.title = project.payload.val().title;
                    p.content = project.payload.val().content;
                    p.created_at = project.payload.val().createdAt;
                    this.posts.push(p);
                });
            });
        return this.posts;
    }

    createProject(title: string, content: string, createdAt: string) {
        this.allPosts.push({ title: title, content: content, created_at: createdAt });
    }

    updateProject(key: string, title: string, content: string) {
        this.allPosts.update(key, { title: title, content: content });
    }

    deleteProject(key: string) {
        this.allPosts.remove(key);
    }

    loadProjectById(id: string): any {
        let post = new Post;
        let p = this.posts.find(x => x._id === id);

        post._id = p._id;
        post.content = p.content;
        post.title = p.title;
        post.created_at = p.created_at;

        return post;
    }
}
