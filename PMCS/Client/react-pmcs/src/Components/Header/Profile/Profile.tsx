import React, { useEffect, useState } from 'react';
import s from './Profile.module.css';
import Button from '@mui/material/Button';
import Face5Icon from '@mui/icons-material/Face5';
import ProfileInfo from './Info/ProfileInfo';
import { ProfileProps } from './ProfileContainer';

export type ProfileInfoProps = Omit<ProfileProps, "fetchOwner">;

const Profile: React.FC<ProfileProps> = ({ fetchOwner, createOwner, editOwner, owner, errors }) => {
    useEffect(() => {
        fetchOwner();
    }, []);

    const [isProfileOpen, setIsProfileOpen] = useState<boolean>(false);
    let toggleProfileSign = isProfileOpen ? String.fromCharCode(9650) : String.fromCharCode(9660);

    return (
        <div className={s.wrapper}>
            <Button onClick={() => setIsProfileOpen(!isProfileOpen)} variant="outlined" size='large' color='success' startIcon={<Face5Icon />} className={s.Button}>
                <span className={s.text}>Profile {toggleProfileSign}</span>
            </Button>
            {isProfileOpen ? <ProfileInfo owner={owner}
                editOwner={editOwner}
                errors={errors}
                createOwner={createOwner} /> : null}
        </div>
    );
}

export default Profile;