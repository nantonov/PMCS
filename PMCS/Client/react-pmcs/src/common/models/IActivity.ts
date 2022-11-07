import { IPet } from "./IPet";

export interface IActivity {
    id: number;
    title: string;
    description: string;
    pet?: IPet;
}