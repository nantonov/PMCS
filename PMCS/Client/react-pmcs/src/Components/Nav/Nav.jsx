import React from 'react';
import s from './Nav.module.css';
import NavItem from './NavItem/NavItem';

const Nav = () => {
    return (
        <nav className={s.nav}>
           <NavItem name='Walkings'/>
           <NavItem name='Meals'/>
           <NavItem name='Vaccines'/>
           <NavItem name='Reminders'/>
           <NavItem name='Pets'/>
        </nav>
    );
}

export default Nav;