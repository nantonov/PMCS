import { axiosInstance } from '../utils/axiosInstance';
import { IUpdateReminderRequest } from '../common/requests/Reminder/IUpdateReminderRequest';
import { toUtcDateTime } from '../utils/dateFormatitng';
import { ICreateReminderRequest } from '../common/requests/Reminder/ICreateReminderRequest';
import { IReminder } from '../common/models/IReminder';
import { AxiosResponse } from 'axios';

class RemindersService {
    public static async getAll(): Promise<Array<IReminder>> {
        const result = await axiosInstance.get(`api/reminders`).
            then((response) => response.data);

        return result;
    }

    public static async create(reminder: ICreateReminderRequest): Promise<AxiosResponse<IReminder>> {
        reminder.triggerDateTime = toUtcDateTime(reminder.triggerDateTime)
        const result = await axiosInstance.post('api/reminders', { ...reminder }).
            then((response) => response.data).
            catch((error) => {
                console.log(error);
                if (error.response.status >= 400) return error.response.data;
            });

        return result;
    }

    public static async update(reminder: IUpdateReminderRequest): Promise<AxiosResponse<IReminder>> {
        reminder.triggerDateTime = toUtcDateTime(reminder.triggerDateTime)
        const result = await axiosInstance.put(`api/reminders`, { ...reminder }).
            then((response) => response.data).
            catch((error) => {
                console.log(error);
                if (error.response.status >= 400) return error.response.data;
            });

        return result;
    }

    public static async delete(reminderId: number): Promise<AxiosResponse<IReminder>> {
        const result = await axiosInstance.delete(`api/reminders/${reminderId}`).
            then((response) => response.data).
            catch((error) => console.log(error));

        return result;
    }

    public static async setReminderStatusDone(reminderId: number): Promise<AxiosResponse<IReminder>> {
        const result = await axiosInstance.put(`api/reminders/complete/${reminderId}`).
            then((response) => response.data).
            catch((error) => {
                console.log(error);
            });

        return result;
    }
}

export default RemindersService;