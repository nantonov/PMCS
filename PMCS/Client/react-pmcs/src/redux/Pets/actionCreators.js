import ownerService from "../../Services/ownerService";
import petsService from "../../Services/petsService";
import { createErrorsListForPets } from "../../utils/createErrorsList";
import { setPets, setisFetching } from "./actions";
import {reset, stopSubmit, startSubmit} from 'redux-form';
import { ADD_FORM, EDIT_FORM } from "./constants";

export const fetchPets = () => {
    return async (dispatch) => {
        dispatch(setisFetching(true));
        const ownerId = await ownerService.getByUserId().then((owner) => owner.id);
        await petsService.getAll(ownerId).then((pets) => {
            dispatch(setPets(pets));
            dispatch(setisFetching(false));
        });
    };
};

export const createPet = (pet) => {
    return async (dispatch) => {
        const result = await petsService.create(pet);
        if (result.status === 400) {
            const errors = createErrorsListForPets(result);
            dispatch(stopSubmit(ADD_FORM, { _error: errors[0] }));
        } else
        {
            startSubmit(EDIT_FORM);
            dispatch(reset(ADD_FORM));
            dispatch(fetchPets());
        }
    };
}

export const editPet = (pet) => {
    return async (dispatch) => {
        const result = await petsService.update(pet);
        if (result.status === 400) {
            const errors = createErrorsListForPets(result);
            dispatch(stopSubmit(EDIT_FORM, { _error: errors[0] }));
        } else
        {
            startSubmit(EDIT_FORM);
            dispatch(fetchPets());
        }
    };
}

export const deletePet = (petId) => {
    return async (dispatch) => {
        const result = await petsService.delete(petId);
        if (result) dispatch(fetchPets());
    };
}