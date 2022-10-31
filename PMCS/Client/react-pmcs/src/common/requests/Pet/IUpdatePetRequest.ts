export interface IUpdatePetRequest {
    id: number;
    name: string;
    info: string;
    weight: number;
    birthDate: string;

    ownerId?: number;
}