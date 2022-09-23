import React from 'react';
import s from './NavItem.module.css';

const NavItem = (props) => {
    return (
        <div className={s.navLink}>
            <a>{props.name}</a>
        </div>
    );
}

export default NavItem;