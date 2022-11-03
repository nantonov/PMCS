import { SET_IS_FETCHING, SET_MEALS, SET_VACCINES, SET_WALKINGS } from "./constants";
import * as actions from './actions';
import { IMeal } from "../../common/models/IMeal";
import { IWalking } from "../../common/models/IWalking";
import { IVaccine } from "../../common/models/IVaccine";

export type ActivitiesState = {
    meals: Array<IMeal>,
    walkings: Array<IWalking>,
    vaccines: Array<IVaccine>,
    isFetching: boolean
};

let initialState: ActivitiesState = {
    meals: [],
    walkings: [],
    vaccines: [],
    isFetching: false
};

export type ActivitiesActions = ReturnType<typeof actions[keyof typeof actions]>;

const activitiesReducer = (state = initialState, action: ActivitiesActions): ActivitiesState => {
    switch (action.type) {
        case SET_MEALS: {
            return { ...state, meals: action.payload }
        }
        case SET_VACCINES: {
            return { ...state, vaccines: action.payload }
        }
        case SET_WALKINGS: {
            return { ...state, walkings: action.payload }
        }
        case SET_IS_FETCHING: {
            return { ...state, isFetching: action.payload }
        }
        default:
            return state;
    }
}

export default activitiesReducer;