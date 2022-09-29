const EDIT_PET = 'EDIT-PET';
const DELETE_PET = 'DELETE-PET';

const petsReducer = (state, action) => {
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