import {SET_OWNER, SET_ERRORS} from './constants';

let initialState = {
    owner: {},
    errors: [],
};

const ownersReducer = (state = initialState, action) => {
    switch (action.type) {
        case SET_OWNER: {
            return {
                ...state, owner: action.owner
            };
        }
        case SET_ERRORS: {
            return {
                 ...state, errors: action.errors
            };
        }
        default:
            return state;
    }
}

export default ownersReducer;