export function createErrorsListForPets(result){
    let errors = [];
    const infoErrors = result.errors?.Info;
    const nameErrors = result.errors?.Name;
    const birthDateErrors = result.errors?.BirthDate;
    const weightErrors = result.errors?.Weight;

    errors = errors.concat(nameErrors, birthDateErrors, weightErrors, infoErrors);

    errors = errors.filter(element => element !== undefined);

    return errors;
}

export function createErrorsListForReminders(result){
    let errors = [];
    const triggerDateTimeErrors = result.errors?.TriggerDateTime;
    const notificationMessageErrors = result.errors?.NotificationMessage;
    const petIdErrors = result.errors?.PetId;
    const actionToRemindTypeErrors = result.errors?.ActionToRemindType;
    const requestErrors = result.errors?.request;

    errors = errors.concat(triggerDateTimeErrors, notificationMessageErrors, petIdErrors, actionToRemindTypeErrors, requestErrors);

    errors = errors.filter(element => element !== undefined);

    return errors;
}