import store from './redux-store';
import { Action } from 'redux';
import { ThunkDispatch } from 'redux-thunk';

export type RootState = ReturnType<typeof store.getState>

export type AppDispatch<T extends Action> = ThunkDispatch<RootState, unknown, T>;

