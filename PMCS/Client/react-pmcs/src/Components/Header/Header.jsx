import React from 'react';
import s from './Header.module.css';
import Profile from './Profile/Profile';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPaw } from '@fortawesome/free-solid-svg-icons'
import NotificationsButton from './Notifications/NotificationsButton';

const Header = () => {
    return (
        <header className={s.header}>
            <div className={s.icon}>
            <FontAwesomeIcon icon={faPaw} size="3x"/>
            </div>
            <div className={s.title}>
                Pets Monitoring and Control System
            </div>
            <div className={s.notifications}>
                <NotificationsButton/>
            </div>
            <div className={s.profile}>
                <Profile/>
            </div>
        </header>
    );
}
export default Header;