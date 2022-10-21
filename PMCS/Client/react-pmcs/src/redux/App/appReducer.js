import {SET_INITIALIZED} from './constants';

let initialState = {
    isInitialized: false,
};

const appReducer = (state = initialState, action) => {
    switch (action.type) {
        case SET_INITIALIZED: {
            return {
                ...state, isInitialized: true
            };
        }
        default:
            return state;
    }
}

export default appReducer;