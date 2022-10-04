const EDIT_PET = 'EDIT-PET';
const DELETE_PET = 'DELETE-PET';
const SET_PETS = 'SET-PETS';
const ADD_PET = 'ADD-PET';

let initialState = {
    pets: [{
        id: 1,
        name: "Johny", info: "Very funny pet.", birthDate: "13/05/2020", weight: "5.0",
        meals: [{ id: 1, title: "Yummy", description: "Very yummy food.", dateTime: "12.05.2012 21.58" }],
        vaccines: [{ id: 1, title: "COVID-19", description: "Remedy.", dateTime: "12.05.2021 21.58" },
        { id: 2, title: "Ebola", description: "", dateTime: "17.05.2022 21.04" },],
        walkings: [{ id: 1, title: "Going to Gorky Park", description: "7 kms for fun", stared: "12.05.2021 21.58", finished: "12.05.2021 22.17" },],
        owner: { id: 1, name: "John" }
    },
    {
        id: 2,
        name: "William", info: "Big old cat.", birthDate: "11/01/2002", weight: "7.28",
        meals: [{ id: 2, title: "Yummy", description: "Very yummy food.", dateTime: "12.05.2012 21.58" }],
        vaccines: [{ id: 3, title: "Yummy", description: "Very yummy food.", dateTime: "12.05.2012 21.58" }],
        walkings: [{ id: 2, title: "Yummy", description: "Very yummy food.", stared: "12.05.2012 21.58", finished: "12.05.2012 22.17" }],
        owner: { id: 2, name: "John" }
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
            stateCopy.pets[petToUpdate].name = action.pet.name;
            stateCopy.pets[petToUpdate].weight = action.pet.weight;

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
        case ADD_PET: {
            return { ...state, pets: [...state.pets, action.pet] };
        }
        default:
            return state;
    }
}

export const editPetActionCreator = (pet) => ({ type: EDIT_PET, pet: pet });
export const deletePetActionCreator = (id) => ({ type: DELETE_PET, id: id });
export const setPetsActionCreator = (pets) => ({ type: SET_PETS, pets: pets });
export const addPetActionCreator = (pet) => ({ type: ADD_PET, pet: pet });

export default petsReducer;