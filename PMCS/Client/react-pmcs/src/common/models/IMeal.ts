import { IActivity } from "./IActivity";

export interface IMeal extends IActivity {
    id: number;
    title: string;
    description: string;
    dateTime: string;
}