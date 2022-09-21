import React from 'react';
import s from './SideBar.module.css';
import NavItem from './NavItem/NavItem';
import Profile from './Profile/Profile';

const SideBar = () => {
    return (
        <nav className={s.sideBar}>
           <Profile ownerName='Daniil Leonchik'/>
           <NavItem name='MyPets'/>
           <NavItem name='Walkings'/>
           <NavItem name='Meals'/>
           <NavItem name='Vaccines'/>
           <NavItem name='Reminders'/>
        </nav>
    );
}

export default SideBar;