import {SET_PETS} from "./constants";

let initialState = {
    pets: []
};

const petsReducer = (state = initialState, action) => {
    switch (action.type) {
        case SET_PETS: {
            return [{ ...state, pets: [...action.pets] }];
        }
        default:
            return state;
    }
}

export default petsReducer;