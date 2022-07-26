import React from 'react';
import s from './Nav.module.css';
import NavItem from './NavItem/NavItem';

const Nav : React.FC = () => {
    return (
        <nav className={s.nav}>
            <NavItem name='Home' path='/' />
            <NavItem name='Pets' path='/pets' />
            <NavItem name='Activities' path='/activities' />
            <NavItem name='Reminders' path='/reminders' />
        </nav>
    );
}

export default Nav;