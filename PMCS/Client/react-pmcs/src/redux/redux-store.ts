import { combineReducers, applyMiddleware, legacy_createStore as createStore } from 'redux';
import ownersReducer from './Owner/ownersReducer';
import petsReducer from './Pets/petsReducer';
import remindersReducer from './Reminders/remindersReducer';
import appReducer from './App/appReducer';
import notificationsReducer from './Notifications/notificationsReducer';
import thunkMiddleware from 'redux-thunk';
import { reducer as formReducer } from 'redux-form';
import activitiesReducer from './Activities/activitiesReducer';

const RootReducer = combineReducers({
    petsPage: petsReducer,
    profile: ownersReducer,
    remindersPage: remindersReducer,
    app: appReducer,
    notifications: notificationsReducer,
    activitiesPage: activitiesReducer,
    form: formReducer,
});

const store = createStore(RootReducer, applyMiddleware(thunkMiddleware));

export default store;