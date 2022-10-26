import { IOwner } from '../../common/models/IOwner';
import {SET_OWNER, SET_ERRORS} from './constants';
import { Nullable } from '../../utils/types/Nullable';
import * as actions from './actions';

export type OwnerState = {
    owner: Nullable<IOwner>,
    errors: Array<String>
}

let initialState : OwnerState = {
    owner: null,
    errors: [],
};

export type OwnerActions = ReturnType<typeof actions[keyof typeof actions]>;

const ownersReducer = (state = initialState, action : OwnerActions) : OwnerState => {
    switch (action.type) {
        case SET_OWNER: {
            return {
                ...state, owner: action.payload
            };
        }
        case SET_ERRORS: {
            return {
                 ...state, errors: action.payload
            };
        }
        default:
            return state;
    }
}

export default ownersReducer;