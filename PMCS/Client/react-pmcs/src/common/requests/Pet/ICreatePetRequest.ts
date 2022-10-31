export interface ICreatePetRequest {
    name: string;
    info: string;
    birthDate: string;
    weight: number;

    ownerId?: number;
}