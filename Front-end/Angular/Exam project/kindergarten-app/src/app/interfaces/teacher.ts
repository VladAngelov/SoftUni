import { IBase } from './base';
import { IGroup } from './group';
import { IPosition } from './position';

export interface ITeacher extends IBase {
    name: string;
    groupId: IGroup;
    positionId: IPosition;
}