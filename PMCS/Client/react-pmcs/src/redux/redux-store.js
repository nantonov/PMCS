import { combineReducers, legacy_createStore as createStore } from 'redux';
import ownersReducer from './reducers/ownersReducer';
import petsReducer from "./reducers/petsReducer";

let reducersBatch = combineReducers({
    petsPage: petsReducer,
    profile: ownersReducer
});

let store = createStore(reducersBatch);


export default store;