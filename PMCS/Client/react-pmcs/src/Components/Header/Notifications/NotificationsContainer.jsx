import { connect } from 'react-redux';
import { useState, useEffect } from 'react';
import NotificationsButton from './NotificationsButton/NotificationsButton';
import s from './NotificationsContainer.module.css';
import { clearMessages, startReceivingMessages } from '../../../redux/Notifications/actionCreators';
import { getHubConnection } from '../../../redux/App/selectors';
import { getMessages } from '../../../redux/Notifications/selectors';
import MessagesList from './MessagesList/MessagesList';

const Notifications = ({ connection, startReceivingMessages, clearMessages, messages }) => {

    const [isNotificationsListOpened, setNotificationsListOpened] = useState(false);

    useEffect(() => {
        startReceivingMessages(connection);
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

export default connect(mapStateToProps, { startReceivingMessages, clearMessages })(Notifications);