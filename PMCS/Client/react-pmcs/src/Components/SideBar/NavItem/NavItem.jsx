import React from 'react';
import s from './NavItem.module.css';

const NavItem = (props) => {
    return (
        <div className={s.navLink}>
            <ul>
                <li>
                    <a>{props.name}</a>
                </li>
            </ul>
        </div>
    );
}

export default NavItem;