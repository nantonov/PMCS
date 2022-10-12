import { combineReducers, applyMiddleware, legacy_createStore as createStore } from 'redux';
import ownersReducer from './Owner/ownersReducer';
import petsReducer from "./Pets/petsReducer";
import thunkMiddleware from 'redux-thunk';

let reducersBatch = combineReducers({
    petsPage: petsReducer,
    profile: ownersReducer
});

let store = createStore(reducersBatch, applyMiddleware(thunkMiddleware));


export default store;