import { axiosInstance } from '../utils/axiosInstance';
import { setRemindersDatesToLocalFormattedDate } from '../utils/dateFormatitng';
import { createRequestForRemindersService } from '../utils/requestCreators/createRequestForRemindersService';

const remindersService = {
    getAll: async () => {
        const reminders = await axiosInstance.get(`api/reminders`).
        then((response) => response.data);

        const result = setRemindersDatesToLocalFormattedDate(reminders);
        return result;
    },
    create: async (reminder) => {
       const request = await createRequestForRemindersService(reminder);

        const result = await axiosInstance.post('api/reminders/', {...request}).
        then((response) => response.data).
        catch((error) => {
            console.log(error);
            if(error.response.status === 400) return error.response.data;
        });

        return result;
    },
    update: async (reminder) => {
        const request = await createRequestForRemindersService(reminder);

        const result = await axiosInstance.put(`api/reminders`, {...request}).
        then((response) => response.data).
         catch((error) => {
            console.log(error);
            if(error.response.status === 400) return error.response.data;
        });

        return result;
    },
    delete: async (reminderId) => {
        const result = await axiosInstance.delete(`api/reminders/${reminderId}`).
        then((response) => response.data).
        catch((error) => console.log(error));

        return result;
    },
    setReminderStatusDone: async (reminderId) => {
        const result = await axiosInstance.put(`api/reminders/complete/${reminderId}`).
        then((response) => response.data).
        catch((error) => {
            console.log(error);
            if(error.response.status === 400) return error.response.data;
        });

        return result;
    },
    resetReminderStatus: async (reminderId) => {
        const result = await axiosInstance.put(`api/reminders/reset/${reminderId}`).
        then((response) => response.data).
        catch((error) => {
            console.log(error);
            if(error.response.status === 400) return error.response.data;
        });

        return result;
    },
};

export default remindersService;