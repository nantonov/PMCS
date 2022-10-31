import { HubConnectionBuilder, HttpTransportType, HubConnection } from '@microsoft/signalr';
import { HUB_URL, RECEIVE_NOTIFICATION_METHOD, SKIP_NEGOTIATION } from '../configuration/signalRConfig';
import { Nullable } from '../utils/types/Nullable';
import authService from './authService';

export class ConnectionService {
    private static _connection: Nullable<HubConnection>;

    public static async connectToHub(): Promise<Nullable<HubConnection>> {

        const user = await authService.getUser();
        if (!user) return null;

        try {
            ConnectionService._connection = new HubConnectionBuilder().
                withUrl(HUB_URL, {
                    transport: HttpTransportType.WebSockets,
                    skipNegotiation: SKIP_NEGOTIATION,
                    accessTokenFactory: () => user.access_token
                }).
                withAutomaticReconnect().
                build();

            return ConnectionService._connection;
        }
        catch (e) {
            console.log(e);

            return null;
        }
    }

    public static async startReceivingMessages(connection: Nullable<HubConnection>, onReceiveNotification: (message: string) => any): Promise<void> {
        try {
            if (!connection) return;
            
            connection.on(RECEIVE_NOTIFICATION_METHOD, (message) => {
                onReceiveNotification(message);
            });
        }
        catch (e) {
            console.log(e);
        }
    }
}

export default ConnectionService;
