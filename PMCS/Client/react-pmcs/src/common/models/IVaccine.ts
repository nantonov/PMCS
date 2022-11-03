import { IActivity } from "./IActivity";

export interface IVaccine extends IActivity {
    id: number;
    title: string;
    description: string;
    dateTime: string;
}