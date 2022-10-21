import { setInitialized, setHubConnection } from "./actions";
import connectionService from "../../Services/connectionService";

export const initializeApp = () => {
    return async (dispatch) => {
        const connection = await connectionService.connectToHub();

        if (connection) {
            await connection.start().then(() => {
                dispatch(setHubConnection(connection));
            });

            dispatch(setInitialized());
            console.log("App initialized");
        }
        else{
            console.log("Connection to hub failed.");
            
            dispatch(setInitialized());
        }
    };
}