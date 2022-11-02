import React from 'react';
import s from './Header.module.css';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPaw } from '@fortawesome/free-solid-svg-icons'
import NotificationsContainer from './Notifications/NotificationsContainer';
import ProfileContainer from './Profile/ProfileContainer';

const Header : React.FC = () => {
    return (
        <header className={s.header}>
            <div className={s.icon}>
                <FontAwesomeIcon icon={faPaw} />
            </div>
            <div className={s.title}>
                Pets Monitoring and Control System
            </div>
            <div className={s.notifications}>
                <NotificationsContainer />
            </div>
            <div className={s.profile}>
                <ProfileContainer />
            </div>
        </header>
    );
}
export default Header;