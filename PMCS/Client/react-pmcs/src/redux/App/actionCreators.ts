import { setInitialized, setHubConnection } from "./actions";
import connectionService from "../../Services/connectionService";
import { InitializedAppActions } from "./appReducer";
import { AppDispatch } from "../types";

export const initializeApp = () => {
    return async (dispatch : AppDispatch<InitializedAppActions>) => {
        const connection = await connectionService.connectToHub();
        if (connection) {
            await connection.start().then(() => {
                dispatch(setHubConnection(connection));
            });

            dispatch(setInitialized());
            console.log("App initialized");
        }
        else {
            console.log("Connection to hub failed.");

            dispatch(setInitialized());
        }
    };
}