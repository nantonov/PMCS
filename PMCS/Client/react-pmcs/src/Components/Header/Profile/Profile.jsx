import React from 'react';
import s from './Profile.module.css';
import Button from '@mui/material/Button';
import Face5Icon from '@mui/icons-material/Face5';

const Profile = () => {
    return (
        <div>
            <Button variant="outlined" color='success' startIcon={<Face5Icon />} className={s.Button}>
                <span className={s.text}>Profile  &#9660;</span>
            </Button>
        </div>
    );
}

export default Profile;