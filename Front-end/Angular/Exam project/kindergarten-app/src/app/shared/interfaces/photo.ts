import { IBase } from './base';

export interface IPhoto extends IBase {
    content: Blob,
    title: string
}