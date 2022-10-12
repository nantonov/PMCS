import { axiosInstance } from '../utils/axiosInstance';
import { createRequestForPetsService } from '../utils/createRequestForPetsService';

const petsService = {
    getAll: async() => {
        const result = await axiosInstance.get(`api/Pet`).
        then((response) => response.data);

        return result;
    },
    getById: async(petId) => {
        const result = await axiosInstance.get(`api/pet/${petId}`).
        then((response) => response.data);

        return result;
    },
    create: async (pet) => {
       const request = await createRequestForPetsService(pet);

        const result = await axiosInstance.post('api/pet/', {...request}).
        then((response) => response.data).
        catch((error) => console.log(error));

        return result;
    },
    update: async (pet) => {
        const request = await createRequestForPetsService(pet);

        const result = await axiosInstance.put(`api/pet/${pet.id}`, {...request}).
        then((response) => response.data).
        catch((error) => console.log(error));

        return result;
    },
    delete: async (petId) => {
        const result = await axiosInstance.delete(`api/pet/${petId}`).
        then((response) => response.data).
        catch((error) => console.log(error));

        return result;
    },
};

export default petsService;