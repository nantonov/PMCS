import  {combineReducers, legacy_createStore as createStore} from 'redux';
import petsReducer from "./petsReducer";

let reducersBatch = combineReducers({
    petsPage: petsReducer,
});

let store = createStore(reducersBatch);


export default store;