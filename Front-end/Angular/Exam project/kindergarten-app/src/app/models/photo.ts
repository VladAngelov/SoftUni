import { IBase } from "../shared/interfaces/base";

export class Photo implements IBase {
    _id: string;
    created_at: string;
    title: string;
    content: any
}