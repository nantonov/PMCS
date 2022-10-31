export interface ICreatePetRequest {
    name: string;
    info: string;
    weight: number;
    birthDate: string;
    
    ownerId?: number;
}