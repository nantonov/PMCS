import { Form } from 'react-router-dom';
import { axiosInstance } from '../utils/axiosInstance';
import authService from '../Services/authService';

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
        const ownerId = await authService.getUser().then((user) => user.profile.sub);
        const request = {
            name: pet.name,
            info: pet.info,
            birthDate: pet.birthDate,
            weight: pet.weight,
            ownerId: 9
        };

        const result = await axiosInstance.post('api/pet/', {...request}).
        then((response) => response.data).
        catch((error) => console.log(error));

        return result;
    },
    update: async (pet) => {
        const result = await axiosInstance.put(`api/pet/${pet.id}`, {...pet}).
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