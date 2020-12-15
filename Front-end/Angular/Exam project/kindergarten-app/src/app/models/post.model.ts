import { IBasePost } from '../shared/interfaces';

export class Post implements IBasePost {
    _id: string;
    content: string;
    title: string;
    created_at: string;
    constructor() { }
}