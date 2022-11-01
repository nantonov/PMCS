import { AxiosResponse } from "axios";
import OwnerService from "./ownerService";
import { IActivity } from "../common/models/IActivity";
import { IMeal } from "../common/models/IMeal";
import { IVaccine } from "../common/models/IVaccine";
import { IWalking } from "../common/models/IWalking";
import { ICreateActivityRequest } from "../common/requests/Activities/ICreateActivityRequest";
import { IUpdateActivityRequest } from "../common/requests/Activities/IUpdateActivityRequest";
import { axiosInstance } from '../utils/axiosInstance';
import { ActivitiyUrl } from "../utils/types/constants";

type Activity = IMeal & IWalking & IVaccine;

class ActivityService {
    public static async getAll(activityUrl: ActivitiyUrl): Promise<Array<Activity>> {
        const ownerId = await OwnerService.getByUserId().then((owner) => owner.id);
        const result = await axiosInstance.get(`api/${activityUrl}/owner/${ownerId}`).
            then((response) => response.data).
            catch((error) => {
                console.log(error);
                if (error.response.status === 404) return null;
            });

        return result;
    }

    public static async getById(activityUrl: ActivitiyUrl, activityId: number): Promise<AxiosResponse<IActivity>> {
        const result = await axiosInstance.get(`api/${activityUrl}/${activityId}`).
            then((response) => response.data).
            catch((error) => {
                console.log(error);
                if (error.response.status === 404) return null;
            });

        return result;
    }

    public static async create(activityUrl: ActivitiyUrl, request: ICreateActivityRequest): Promise<AxiosResponse<IActivity>> {
        const result = await axiosInstance.post(`api/${activityUrl}`, { ...request }).
            then((response) => response.data).
            catch((error) => {
                console.log(error);
                if (error.response.status === 400) return error.response.data;
            });

        return result;
    }

    public static async update(activityUrl: ActivitiyUrl, request: IUpdateActivityRequest): Promise<AxiosResponse<IActivity>> {
        const result = await axiosInstance.put(`api/${activityUrl}/${request.id}`, { ...request }).
            then((response) => response.data).
            catch((error) => {
                console.log(error);
                if (error.response.status === 400) return error.response.data;
            });

        return result;
    }

    public static async delete(activityUrl: ActivitiyUrl, activityId : number): Promise<AxiosResponse<IActivity>> {
        const result = await axiosInstance.delete(`api/${activityUrl}/${activityId}`).
            then((response) => response.data).
            catch((error) => {
                console.log(error);
                if (error.response.status === 400) return error.response.data;
            });

        return result;
    }
}

export default ActivityService;