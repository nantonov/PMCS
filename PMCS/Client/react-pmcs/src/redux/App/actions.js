import { SET_INITIALIZED, SET_HUB_CONNECTION} from "./constants";

export const setInitialized = () => ({ type: SET_INITIALIZED });
export const setHubConnection = (connection) => ({type: SET_HUB_CONNECTION, connection: connection});