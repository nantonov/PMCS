import { connect, ConnectedProps } from 'react-redux';
import { useState, useEffect } from 'react';
import NotificationsButton from './NotificationsButton/NotificationsButton';
import s from './NotificationsContainer.module.css';
import { clearMessages, startReceivingMessages } from '../../../redux/Notifications/actionCreators';
import { getHubConnection } from '../../../redux/App/selectors';
import { getMessages } from '../../../redux/Notifications/selectors';
import MessagesList from './MessagesList/MessagesList';
import { RootState } from '../../../redux/types';

function mapStateToProps(state: RootState) {
    return {
        connection: getHubConnection(state),
        messages: getMessages(state)
    };
}

const connector = connect(mapStateToProps, { startReceivingMessages, clearMessages });

type NotificationsProps = ConnectedProps<typeof connector>;

const Notifications: React.FC<NotificationsProps> = ({ connection, startReceivingMessages, clearMessages, messages }) => {

    const [isNotificationsListOpened, setNotificationsListOpened] = useState<boolean>(false);

    useEffect(() => {
        startReceivingMessages(connection);
        console.log(messages);
    }, [messages]);

    const onToggleNotificationsList = () : void => {
        setNotificationsListOpened(!isNotificationsListOpened);
    }

    const isUserNotified = messages.length > 0;

    return (
        <div className={s.wrapper}>
            <div>
                <NotificationsButton onToggleNotificationsList={onToggleNotificationsList} isUserNotified={isUserNotified} />
                {isNotificationsListOpened && <MessagesList messages={messages} clearMessages={clearMessages} isUserNotified={isUserNotified} />}
            </div>
        </div>
    );
}

export default connector(Notifications);