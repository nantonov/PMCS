import { IOwner } from "../../common/models/IOwner";
import ownerService from "../../Services/ownerService";
import { AppDispatch } from "../types";
import { setOwner, setErrors } from "./actions";
import { OWNER_INITIAL_USERNAME } from "./constants";
import { OwnerActions } from "./ownersReducer";

export const fetchOwner = () => {
    return async (dispatch : AppDispatch<OwnerActions>) => {
        const owner = await ownerService.getByUserId();
        dispatch(setOwner(owner));
    };
};

export const createOwner = () => {
    return async (dispatch : AppDispatch<OwnerActions>) => {
        const initialName = OWNER_INITIAL_USERNAME;
        const request = { fullName: initialName };
        const createdOwner = await ownerService.create(request);
        if (createdOwner) dispatch(fetchOwner());
    };
}

export const editOwner = (owner : IOwner) => {
    return async (dispatch : AppDispatch<OwnerActions>) => {
        const result = await ownerService.update(owner);
        if (result.status === 400) {
            const errors = result.errors?.FullName;
            dispatch(setErrors(errors));
        }
        else {
            dispatch(setErrors([]));
        }
    };
}