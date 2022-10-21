import { setInitialized } from "./actions";

export const initializeApp = () => {
    return async (dispatch) => {
        dispatch(setInitialized());
    };
}