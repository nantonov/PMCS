import { combineReducers, legacy_createStore as createStore } from 'redux';
import ownersReducer from './reducers/ownersReducer/ownersReducer';
import petsReducer from "./reducers/petsReducer/petsReducer";

let reducersBatch = combineReducers({
    petsPage: petsReducer,
    profile: ownersReducer
});

let store = createStore(reducersBatch);


export default store;