import { AxiosResponse } from "axios";
import { IActivity } from "../common/models/IActivity";
import { ICreateActivityRequest } from "../common/requests/Activities/ICreateActivityRequest";
import { IUpdateActivityRequest } from "../common/requests/Activities/IUpdateActivityRequest";
import { axiosInstance } from '../utils/axiosInstance';

class ActivityService {
    public static async getAll(activityUrl: string): Promise<AxiosResponse<Array<IActivity>>> {
        const result = await axiosInstance.get(`api/${activityUrl}`).
            then((response) => response.data).
            catch((error) => {
                console.log(error);
                if (error.response.status === 404) return null;
            });

        return result;
    }

    public static async getById(activityUrl: string, activityId: number): Promise<AxiosResponse<IActivity>> {
        const result = await axiosInstance.get(`api/${activityUrl}/${activityId}`).
            then((response) => response.data).
            catch((error) => {
                console.log(error);
                if (error.response.status === 404) return null;
            });

        return result;
    }

    public static async create(activityUrl: string, request: ICreateActivityRequest): Promise<AxiosResponse<IActivity>> {
        const result = await axiosInstance.post(`api/${activityUrl}`, { ...request }).
            then((response) => response.data).
            catch((error) => {
                console.log(error);
                if (error.response.status === 400) return error.response.data;
            });

        return result;
    }

    public static async update(activityUrl: string, request: IUpdateActivityRequest): Promise<AxiosResponse<IActivity>> {
        const result = await axiosInstance.put(`api/${activityUrl}/${request.id}`, { ...request }).
            then((response) => response.data).
            catch((error) => {
                console.log(error);
                if (error.response.status === 400) return error.response.data;
            });

        return result;
    }
}

export default ActivityService;