function toLocalDate(date) {
    let localDate = new Date(date);
    const options = { year: 'numeric', month: 'long', day: 'numeric' };

    return localDate.toLocaleDateString('en-US',options).replace('.', '-').replace('.', '-');
}

function toLocalDateTime(date) {
    let localDate = new Date(date);
    const options = { year: 'numeric', month: 'long', day: 'numeric', hour: '2-digit', minute: '2-digit' };
    return localDate.toLocaleDateString('en-US', options);
}

export function toServerFormatDate(date) {
    let localDate = new Date(date);

    let day = localDate.getDate();
    let month = localDate.getMonth() + 1;
    let year = localDate.getFullYear(); 

    day = day < 10 ? '0' + day : day;
    month = month < 10 ? '0' + month : month;

    const result = `${year}-${month}-${day}`;
    return result;
}

export function setPetDatesToLocalFormattedDate(pets) {
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