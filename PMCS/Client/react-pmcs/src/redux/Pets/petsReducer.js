import { SET_IS_FETCHING, SET_PETS, SET_ERRORS } from "./constants";

let initialState = {
    pets: [],
    isFetching: false,
    errors: [],
};

const petsReducer = (state = initialState, action) => {
    switch (action.type) {
        case SET_PETS: {
            return { ...state, pets: action.pets }
        }
        case SET_IS_FETCHING: {
            return { ...state, isFetching: action.isFetching }
        }
        case SET_ERRORS: {
            return { ...state, errors: action.errors }
        }
        default:
            return state;
    }
}

export default petsReducer;