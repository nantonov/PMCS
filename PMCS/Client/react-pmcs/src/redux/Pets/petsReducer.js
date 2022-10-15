import { SET_IS_FETCHING, SET_PETS } from "./constants";

let initialState = {
    pets: [],
    isFetching: false,
};

const petsReducer = (state = initialState, action) => {
    switch (action.type) {
        case SET_PETS: {
            return { ...state, pets: action.pets }
        }
        case SET_IS_FETCHING: {
            return { ...state, isFetching: action.isFetching }
        }
        default:
            return state;
    }
}

export default petsReducer;