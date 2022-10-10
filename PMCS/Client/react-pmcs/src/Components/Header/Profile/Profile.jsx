import React, { useState } from 'react';
import s from './Profile.module.css';
import Button from '@mui/material/Button';
import Face5Icon from '@mui/icons-material/Face5';
import ProfileInfo from './Info/ProfileInfo';

const Profile = props => {
    const [isProfileOpen, setIsProfileOpen] = useState(false);

    let toggleProfileSign = isProfileOpen ? String.fromCharCode(9650) : String.fromCharCode(9660);

    return (
        <div className={s.wrapper}>
            <Button onClick={() => setIsProfileOpen(!isProfileOpen)} variant="outlined" size='large' color='success' startIcon={<Face5Icon />} className={s.Button}>
                <span className={s.text}>Profile {toggleProfileSign}</span>
            </Button>
            {isProfileOpen ? <ProfileInfo owner={props.owner}
                editOwner={props.editOwner} /> : null}
        </div>
    );
}

export default Profile;