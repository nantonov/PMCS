export interface IUpdatePetRequest {
    id: number;
    name: string;
    info: string;
    weight: number;

    ownerId?: number;
}