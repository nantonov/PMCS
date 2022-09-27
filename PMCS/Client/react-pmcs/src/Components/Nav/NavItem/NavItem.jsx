import React from 'react';
import s from './NavItem.module.css';
import { NavLink } from 'react-router-dom';

const NavItem = (props) => {
    return (
        <div className={s.navLink}>
            <NavLink to={props.path}>
                {props.name}
            </NavLink>
        </div>
    );
}

export default NavItem;