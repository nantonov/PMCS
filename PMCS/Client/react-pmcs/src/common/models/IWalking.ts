import { IActivity } from "./IActivity";

export interface IWalking extends IActivity {
    id: number;
    title: string;
    description: string;
    stared: string;
    finished: string;
}