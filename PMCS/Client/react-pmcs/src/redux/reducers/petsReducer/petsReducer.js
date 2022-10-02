const EDIT_PET = 'EDIT-PET';
const DELETE_PET = 'DELETE-PET';
const SET_PETS = 'SET-PETS';

let initialState = {
    pets: [{
        id: 1,
        name: "Johny", info: "Very funny pet.", birthDate: "12/05/2012", weight: "5.0kg",
        meals: [{ id: 1, title: "Yummy", description: "Very yummy food.", dateTime: "12.05.2012 21.58" }],
        vaccines: [{ id: 1, title: "Yummy", description: "Very yummy food.", dateTime: "12.05.2012 21.58" }],
        walkings: [{ id: 1, title: "Yummy", description: "Very yummy food.", stared: "12.05.2012 21.58", finished: "12.05.2012 22.17" }],
        owner: { id: 1, name: "John" }
    },
    {
        id: 2,
        name: "William", info: "Very funny pet.", birthDate: "12/05/2012", weight: "5.0kg",
        meals: [{ id: 1, title: "Yummy", description: "Very yummy food.", dateTime: "12.05.2012 21.58" }],
        vaccines: [{ id: 1, title: "Yummy", description: "Very yummy food.", dateTime: "12.05.2012 21.58" }],
        walkings: [{ id: 1, title: "Yummy", description: "Very yummy food.", stared: "12.05.2012 21.58", finished: "12.05.2012 22.17" }],
        owner: { id: 1, name: "John" }
    },
]
};

const petsReducer = (state = initialState, action) => {
    let stateCopy;

    switch (action.type) {
        case EDIT_PET: {
            stateCopy = {
                ...state,
                pets: [...state.pets]
            };

            let petToUpdate = stateCopy.pets.findIndex(p => p.id === action.pet.id);
            stateCopy.pets[petToUpdate] = action.pet;

            return stateCopy;
        }
        case DELETE_PET: {
            stateCopy = {
                ...state,
                pets: [...state.pets]
            };

            stateCopy.pets.pop(x => x.id === action.id);

            return stateCopy;
        }
        case SET_PETS: {
            return { ...state, pets: [...action.pets] };
        }
        default:
            return state;
    }
}

export const editPetActionCreator = (pet) => ({ type: EDIT_PET, pet: pet });
export const deletePetActionCreator = (id) => ({ type: DELETE_PET, id: id });
export const setPetsActionCreator = (pets) => ({ type: SET_PETS, pets: pets });

export default petsReducer;