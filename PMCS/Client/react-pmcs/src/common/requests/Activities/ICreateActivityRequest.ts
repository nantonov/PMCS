import { ActivityType } from "../../../Enums/activityEnums";

export interface ICreateActivityRequest {
    title: string;
    desctiption: string;
    dateTime?: string;
    stared?: string;
    finished?: string;
    activityType: ActivityType;
    petId: number;
}