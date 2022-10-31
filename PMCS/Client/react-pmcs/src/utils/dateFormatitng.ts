import DateTimeFormatOptions = Intl.DateTimeFormatOptions;
import { IPet } from "../common/models/IPet";
import { IReminder } from "../common/models/IReminder";

function toLocalDate(date: string): string {
    let localDate = new Date(date);
    const options: DateTimeFormatOptions = { year: 'numeric', month: 'long', day: 'numeric' };

    return localDate.toLocaleDateString('en-US', options).replace('.', '-').replace('.', '-');
}

function toLocalDateTime(date: string): string {
    let localDate = new Date(date);
    const options: DateTimeFormatOptions = { year: 'numeric', month: 'long', day: 'numeric', hour: '2-digit', minute: '2-digit' };
    return localDate.toLocaleDateString('en-US', options);
}

export function toServerFormatDate(date: string): string {
    let localDate = new Date(date);

    let day: number | string = localDate.getDate();
    let month: number | string = localDate.getMonth() + 1;
    let year: number | string = localDate.getFullYear();

    day = day < 10 ? '0' + day : day;
    month = month < 10 ? '0' + month : month;

    const result = `${year}-${month}-${day}`;
    return result;
}

export function toUtcDateTime(date: string): string {
    let localDate = new Date(date);

    const utcDateTime = localDate.toISOString();
    return utcDateTime;
}

export function setPetDatesToLocalFormattedDate(pets: Array<IPet>): Array<IPet> {
    const result = pets.map((pet) => {
        pet.birthDate = toLocalDate(pet.birthDate);

        pet.meals = pet.meals.map((meal) => {
            meal.dateTime = toLocalDateTime(meal.dateTime);

            return meal;
        });
        pet.vaccines = pet.vaccines.map((vaccine) => {
            vaccine.dateTime = toLocalDateTime(vaccine.dateTime);

            return vaccine;
        });
        pet.walkings = pet.walkings.map((walking) => {
            walking.stared = toLocalDateTime(walking.stared);
            walking.finished = toLocalDateTime(walking.finished);

            return walking;
        });

        return pet;
    });

    return result;
}

export function setRemindersDatesToLocalFormattedDate(reminders: Array<IReminder>): Array<IReminder> {
    const result = reminders.map((reminder) => {
        reminder.triggerDateTime = toLocalDateTime(reminder.triggerDateTime);
        reminder.lastModified = toLocalDateTime(reminder.lastModified);

        return reminder;
    });

    return result;
}