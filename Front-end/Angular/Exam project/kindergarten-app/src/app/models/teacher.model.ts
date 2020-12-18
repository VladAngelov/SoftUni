import { ITeacher } from "../shared/interfaces";

export class Teacher implements ITeacher {
    _id: string;
    name: string;
    group: string;
    position: string;
    constructor() { }
    created_at: string;
}