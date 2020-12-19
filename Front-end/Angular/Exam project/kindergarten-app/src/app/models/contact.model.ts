import { IContact } from "../shared/interfaces";

export class Contact implements IContact {
    name: string;
    content: string;
    _id: string;
    created_at: string;
    constructor() { }
}