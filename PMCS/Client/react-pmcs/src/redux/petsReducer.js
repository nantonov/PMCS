const EDIT_PET = 'EDIT-PET';
const DELETE_PET = 'DELETE-PET';

let initialState = {
    pets: [{
        id: 1,
        name: "Johny", info: "Very funny pet.", birthdate: "12/05/2012", weight: "5.0kg",
        meals: [{ id: 1, title: "Yummy", description: "Very yummy food.", dateTime: "12.05.2012 21.58" }],
        vaccines: [{ id: 1, title: "Yummy", description: "Very yummy food.", dateTime: "12.05.2012 21.58" }],
        walkings: [{ id: 1, title: "Yummy", description: "Very yummy food.", started: "12.05.2012 21.58", finished: "12.05.2012 22.17" }],
        owner: { id: 1, name: "John" }
    }]
};

const petsReducer = (state = initialState, action) => {
    switch (action.type) {
        case EDIT_PET:
            let petToUpdate = state.pets.findIndex(p => p.id === action.pet.id);
            state.pets[petToUpdate].name = 'hiuhiu';
    
            return state;
        case DELETE_PET:
            state.pets.pop(x => x.id === action.id);

            return state;
        default:
            return state;
    }
}

export const editPetActionCreator = (pet) => ({ type: EDIT_PET, pet: pet });
export const deletePetActionCreator = (id) => ({ type: DELETE_PET, id: id })

export default petsReducer;