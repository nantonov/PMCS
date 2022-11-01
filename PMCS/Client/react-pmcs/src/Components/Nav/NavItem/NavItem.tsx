import React from 'react';
import s from './NavItem.module.css';
import { NavLink } from 'react-router-dom';

type NavItemProps = {
    path: string;
    name: string;
}

const NavItem: React.FC<NavItemProps> = ({ path, name }) => {
    return (
        <div className={s.navLink}>
            <NavLink to={path}>
                {name}
            </NavLink>
        </div>
    );
}

export default NavItem;