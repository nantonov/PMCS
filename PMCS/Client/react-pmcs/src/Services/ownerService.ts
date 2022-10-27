import { axiosInstance } from '../utils/axiosInstance';
import authService from './authService';
import { ICreateOwnerRequest } from '../common/requests/Owner/ICreateOnwerRequest';
import { IUpdateOwnerRequest } from '../common/requests/Owner/IUpdateOwnerRequest';

class OwnerService {
    public static async getByUserId(): Promise<any> {
        const userId = await authService.getUser().then((user) => user?.profile.sub);
        const result = await axiosInstance.get(`api/Owner/userId/${userId}`).
            then((response) => response.data).
            catch((error) => {
                console.log(error);
                if (error.response.status === 404) return null;
            });

        return result;
    }

    public static async create(request : ICreateOwnerRequest): Promise<any> {
        const result = await axiosInstance.post('api/owner', { ...request }).
            then((response) => response.data).
            catch((error) => {
                console.log(error);
                if (error.response.status === 400) return error.response.data;
            });

        return result;
    }

    public static async update(owner: IUpdateOwnerRequest): Promise<any> {
        const request = { fullName: owner.fullName };
        const result = await axiosInstance.put(`api/owner/${owner.id}`, { ...request }).
            then((response) => response.data).
            catch((error) => {
                console.log(error);
                if (error.response.status === 400) return error.response.data;
            });

        return result;
    }
}

export default OwnerService;