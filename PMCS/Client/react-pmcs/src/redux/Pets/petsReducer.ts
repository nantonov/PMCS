import { IPet } from "../../common/models/IPet";
import { SET_IS_FETCHING, SET_PETS } from "./constants";
import * as actions from './actions';

export type PetsState = {
    pets: Array<IPet>,
    isFetching: boolean
};

let initialState: PetsState = {
    pets: [],
    isFetching: false
};

export type PetsActions = ReturnType<typeof actions[keyof typeof actions]>;

const petsReducer = (state = initialState, action: PetsActions): PetsState => {
    switch (action.type) {
        case SET_PETS: {
            return { ...state, pets: action.payload }
        }
        case SET_IS_FETCHING: {
            return { ...state, isFetching: action.payload }
        }
        default:
            return state;
    }
}

export default petsReducer;