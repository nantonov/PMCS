import { axiosInstance } from '../utils/axiosInstance';
import { IPet } from '../common/models/IPet';
import { ICreatePetRequest } from '../common/requests/Pet/ICreatePetRequest';
import { IUpdatePetRequest } from '../common/requests/Pet/IUpdatePetRequest';
import OwnerService from './ownerService';
import {AxiosResponse } from 'axios';

class PetsService {
    public static async getAll(ownerId: number): Promise<Array<IPet>> {
        const result = await axiosInstance.get(`api/Pet/ownerId/${ownerId}`).
            then((response) => response.data);

        return result;
    }

    public static async getById(petId: number): Promise<AxiosResponse<IPet>> {
        const result = await axiosInstance.get(`api/Pet/${petId}`).
            then((response) => response.data);

        return result;
    }

    public static async update(pet: IUpdatePetRequest): Promise<AxiosResponse<IPet>> {
        const ownerId = await OwnerService.getByUserId().then((owner) => owner.id);
        pet.ownerId = ownerId;

        const result = await axiosInstance.put(`api/pet/${pet.id}`, { ...pet }).
            then((response) => response.data).
            catch((error) => {
                console.log(error);
                if (error.response.status === 400) return error.response.data;
            });

        return result;
    }

    public static async delete(petId: number): Promise<AxiosResponse<IPet>> {
        const result = await axiosInstance.delete(`api/pet/${petId}`).
            then((response) => response.data).
            catch((error) => console.log(error));

        return result;
    }

    public static async create(pet: ICreatePetRequest): Promise<AxiosResponse<IPet>> {
        const ownerId = await OwnerService.getByUserId().then((owner) => owner.id);
        pet.ownerId = ownerId;

        const result = await axiosInstance.post('api/pet/', { ...pet }).
            then((response) => response.data).
            catch((error) => {
                console.log(error);
                if (error.response.status === 400) return error.response.data;
            });

        return result;
    }
}


export default PetsService;