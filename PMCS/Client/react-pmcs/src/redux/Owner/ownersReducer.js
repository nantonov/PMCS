import {SET_OWNER} from './constants';

let initialState = {
    owner: {}
};

const ownersReducer = (state = initialState, action) => {
    switch (action.type) {
        case SET_OWNER: {
            return {
                ...state, owner: action.owner
            };
        }
        default:
            return state;
    }
}

export default ownersReducer;