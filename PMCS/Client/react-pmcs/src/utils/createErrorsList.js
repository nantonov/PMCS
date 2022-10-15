export function createErrorsListForPets(result){
    let errors = [];
    const infoErrors = result.errors?.Info;
    const nameErrors = result.errors?.Name;
    const birthDateErrors = result.errors?.BirthDate;
    const weightErrors = result.errors?.Weight;

    errors = errors.concat(nameErrors, birthDateErrors, weightErrors, infoErrors);

    return errors;
}