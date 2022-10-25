import { HubConnectionBuilder, HttpTransportType } from '@microsoft/signalr';
import { HUB_URL, RECEIVE_NOTIFICATION_METHOD, SKIP_NEGOTIATION } from '../configuration/signalRConfig';
import authService from './authService';

const connectionService = {

    connectToHub: async () => {

        const user = await authService.getUser();
        if (!user) return null;

        try {
            const connection = new HubConnectionBuilder().
                withUrl(HUB_URL, {
                    transport: HttpTransportType.WebSockets,
                    skipNegotiation: SKIP_NEGOTIATION,
                    accessTokenFactory: () => user.access_token
                }).
                withAutomaticReconnect().
                build();

            return connection;
        }
        catch (e) {
            console.log(e);

            return null;
        }
    },

    startReceivingMessages: async (connection, onReceiveNotification) => {
        connection.on(RECEIVE_NOTIFICATION_METHOD, (message) => {
            onReceiveNotification(message);
        });
    }
}

export default connectionService;
