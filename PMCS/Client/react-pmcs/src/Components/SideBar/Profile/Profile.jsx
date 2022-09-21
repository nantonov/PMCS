import React from 'react';
import s from './Profile.module.css';
import Face5Icon from '@mui/icons-material/Face5';

const Profile = (props) => {
    return (
        <div className={s.profile}>
            <div className={s.userIcon}>
                <Face5Icon sx={{ fontSize: 40 }} />
            </div>
            <div className={s.ownerName}>
                {props.ownerName}
                <div className={s.settings}>
                    Edit
                </div>
            </div>
        </div>
    );
}

export default Profile;