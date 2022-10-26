import { IOwner } from "./IOwner";
import { IVaccine } from "./IVaccine";
import { IWalking } from "./IWalking";
import { IMeal } from "./IMeal";

export interface IPet {
    id: number;
    name: string;
    info: string;
    birthDate: string;
    weight: number;

    owner: IOwner;
    meals: Array<IMeal>;
    walkings: Array<IWalking>;
    vaccines: Array<IVaccine>;
}