import { axiosInstance } from '../utils/axiosInstance';
import authService from '../Services/authService';
import { useMemo } from 'react';

const ownerService = {
    getByUserId: async() => {
        const userId = await authService.getUser().then((user) => user.profile.sub);
        const result = await axiosInstance.get(`api/Owner/userId/${userId}`).
        then((response) => response.data).
        catch((error) => {
            console.log(error);
            if(error.response.status === 404) return null;
        });

        return result;
    },
    create: async(request) => {
        const result = await axiosInstance.post('api/owner', {...request}).
        then((response) => response.data).
        catch((error) => {
            console.log(error);
            if(error.response.status === 400) return error.response.data;
        });

        return result;
    },
    update: async(owner) => {
        const request = {fullName:owner.fullName};
        const result = await axiosInstance.put(`api/owner/${owner.id}`, {...request}).
        then((response) => response.data).
        catch((error) => {
            console.log(error);
            if(error.response.status === 400) return error.response.data;
        });

        return result;
    }
};

export default ownerService;