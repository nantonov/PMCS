import React from 'react';
import s from './Header.module.css';
import Profile from './Profile/Profile';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPaw } from '@fortawesome/free-solid-svg-icons'
import NotificationsButton from './Notifications/NotificationsButton';
import ProfileContainer from './Profile/ProfileContainer';

const Header = () => {
    return (
        <header className={s.header}>
            <div className={s.icon}>
            <FontAwesomeIcon icon={faPaw} />
            </div>
            <div className={s.title}>
                Pets Monitoring and Control System
            </div>
            <div className={s.notifications}>
                <NotificationsButton/>
            </div>
            <div className={s.profile}>
                <ProfileContainer/>
            </div>
        </header>
    );
}
export default Header;