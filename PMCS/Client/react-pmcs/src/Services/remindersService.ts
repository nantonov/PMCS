import { axiosInstance } from '../utils/axiosInstance';
import { IReminder } from '../common/models/IReminder';
import { IUpdateReminderRequest } from '../common/requests/Reminder/IUpdateReminderRequest';
import { toUtcDateTime } from '../utils/dateFormatitng';
import { ICreateReminderRequest } from '../common/requests/Reminder/ICreateReminderRequest';

class RemindersService {
    public static async getAll(): Promise<any> {
        const result = await axiosInstance.get(`api/reminders`).
            then((response) => response.data);

        return result;
    }

    public static async create(reminder: ICreateReminderRequest): Promise<any> {
        reminder.triggerDateTime = toUtcDateTime(reminder.triggerDateTime)
        const result = await axiosInstance.post('api/reminders', { ...reminder }).
            then((response) => response.data).
            catch((error) => {
                console.log(error);
            });

        return result;
    }

    public static async update(reminder: IUpdateReminderRequest): Promise<any> {
        reminder.triggerDateTime = toUtcDateTime(reminder.triggerDateTime)
        const result = await axiosInstance.put(`api/reminders`, { ...reminder }).
            then((response) => response.data).
            catch((error) => {
                console.log(error);
            });

        return result;
    }

    public static async delete(reminderId: number): Promise<any> {
        const result = await axiosInstance.delete(`api/reminders/${reminderId}`).
            then((response) => response.data).
            catch((error) => console.log(error));

        return result;
    }

    public static async setReminderStatusDone(reminderId: number): Promise<any> {
        const result = await axiosInstance.put(`api/reminders/complete/${reminderId}`).
            then((response) => response.data).
            catch((error) => {
                console.log(error);
            });

        return result;
    }
}

export default RemindersService;