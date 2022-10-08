const EDIT_OWNER = 'EDIT-OWNER';
const SET_OWNER = 'SET-OWNER';
const ADD_OWNER = 'ADD-OWNER';

let initialState = {
    owner: { id: 1, fullName: "John Luke" }
};

const ownersReducer = (state = initialState, action) => {
    switch (action.type) {
        case EDIT_OWNER: {
            return {
                ...state,
                owner: { ...state.owner, fullName: action.owner.fullName }
            };
        }
        case ADD_OWNER:
        case SET_OWNER: {
            return {
                ...state,
                owner: action.owner
            };
        }
        default:
            return state;
    }
}

export const editOwner = (owner) => ({ type: EDIT_OWNER, owner: owner });
export const setOwner = (owner) => ({ type: SET_OWNER, owner: owner });
export const addOwner = (owner) => ({ type: ADD_OWNER, owner: owner });

export default ownersReducer;