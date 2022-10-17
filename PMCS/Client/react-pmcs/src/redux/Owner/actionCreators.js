import ownerService from "../../Services/ownerService";
import { setOwner } from "./actions";
import { OWNER_INITIAL_USERNAME } from "./constants";


export const fetchOwner = () => {
    return async (dispatch) => {
        const owner = await ownerService.getByUserId();
        dispatch(setOwner(owner));
    };
};

export const createOwner = () => {
    return async (dispatch) => {
        const initialName = OWNER_INITIAL_USERNAME;
        const request = {fullName: initialName};
        const createdOwner = await ownerService.create(request);
        if(createdOwner) dispatch(fetchOwner());
    };
}

export const editOwner = (owner) => {
    return async (dispatch) => {
        const result = await ownerService.update(owner);
        if(result) dispatch(fetchOwner());
    };
}