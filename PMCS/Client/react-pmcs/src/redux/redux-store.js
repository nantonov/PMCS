import { combineReducers, applyMiddleware, legacy_createStore as createStore } from 'redux';
import ownersReducer from './Owner/ownersReducer';
import petsReducer from "./Pets/petsReducer";
import remindersReducer from './Reminders/remindersReducer';
import appReducer from './App/appReducer';
import thunkMiddleware from 'redux-thunk';
import { reducer as formReducer } from 'redux-form';

let reducersBatch = combineReducers({
    petsPage: petsReducer,
    profile: ownersReducer,
    remindersPage: remindersReducer,
    app: appReducer,
    form: formReducer,
});

let store = createStore(reducersBatch, applyMiddleware(thunkMiddleware));

export default store;