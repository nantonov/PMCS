import ownerService from "../../Services/ownerService";
import petsService from "../../Services/petsService";
import { setPets, setisFetching } from "./actions";

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
        const createdPet = await petsService.create(pet);
        if(createdPet) dispatch(fetchPets());
    };
}

export const editPet = (pet) => {
    return async (dispatch) => {
        const result = await petsService.update(pet);
        if(result) dispatch(fetchPets());
    };
}

export const deletePet = (petId) => {
    return async (dispatch) => {
        const result = await petsService.delete(petId);
        if(result) dispatch(fetchPets());
    };
}