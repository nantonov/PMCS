import { connect } from 'react-redux';
import { useState, useEffect } from 'react';
import NotificationsButton from './NotificationsButton/NotificationsButton';
import s from './NotificationsContainer.module.css';
import connectionService from '../../../Services/connectionService';
import { notify, clearMessages } from '../../../redux/Notifications/actionCreators';
import { getHubConnection } from '../../../redux/App/selectors';
import { getMessages } from '../../../redux/Notifications/selectors';
import MessagesList from './MessagesList/MessagesList';

const Notifications = ({ connection, notify, clearMessages, messages }) => {

    const [isNotificationsListOpened, setNotificationsListOpened] = useState(false);

    useEffect(() => {
        connectionService.startReceivingMessages(connection, notify);
        console.log(messages);
    }, [messages]);

    const onToggleNotificationsList = () => {
        setNotificationsListOpened(!isNotificationsListOpened);
    }

    const isUserNotified = messages.length > 0;

    return (
        <div className={s.wrapper}>
            <div>
                <NotificationsButton onToggleNotificationsList={onToggleNotificationsList} isUserNotified={isUserNotified}/>
                {isNotificationsListOpened && <MessagesList messages={messages} clearMessages={clearMessages} isUserNotified={isUserNotified}/>}
            </div>
        </div>
    );
}

function mapStateToProps(state) {
    return {
        connection: getHubConnection(state),
        messages: getMessages(state)
    };
}

export default connect(mapStateToProps, { notify, clearMessages })(Notifications);