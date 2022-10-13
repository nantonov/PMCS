import ownerService from "../../Services/ownerService";
import petsService from "../../Services/petsService";
import { setPets } from "./actions";

export const fetchPets = () => {
    return async (dispatch) =>{
        const ownerId = await ownerService.getByUserId().then((owner) => owner.id);
        const pets = await petsService.getAll(ownerId);
        dispatch(setPets(pets));
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