import React, { useState, useEffect } from 'react';
import s from './ProfileInfo.module.css';
import IconButton from '@mui/material/IconButton';
import EditIcon from '@mui/icons-material/Edit';
import authService from '../../../../Services/authService';
import { Button } from '@mui/material';
import { useAuthContext } from '../../../Auth/AuthProvider';
import { ProfileInfoProps } from '../Profile';
import { Nullable } from '../../../../utils/types/Nullable';

const ProfileInfo: React.FC<ProfileInfoProps> = ({ owner, editOwner, createOwner, errors }) => {

    const [name, setName] = useState<string>('');
    const [email, setEmail] = useState<string | undefined>('');
    const [error, setError] = useState<Nullable<String> | undefined>(null);

    useEffect(() => {
        errors !== null ? setError(errors.at(0)) : setError('');
        owner === null ? createOwner() : setName(owner?.fullName);
        user !== null ? setEmail(user.profile?.email) : setEmail('');
    }, [owner, errors]);

    const [isEdit, setIsEdit] = useState<boolean>(false);
    const { isAuth, user } = useAuthContext();

    const activateEditMode = (): void => {
        setIsEdit(true);
    };

    const deactivateEditMode = (): void => {
        setIsEdit(false);

        if (owner !== null) {
            owner.fullName = name;
            editOwner(owner);
        }
    };

    const onNameChanged = (e: React.FormEvent<HTMLInputElement>) => {
        setName(e.currentTarget.value);
    }

    return (<div className={s.wrapper}>
        {!isEdit &&
            <div className={s.info}>
                {isAuth && owner && <span className={s.name}>
                    {owner?.fullName}
                    <IconButton onClick={activateEditMode}>
                        <EditIcon fontSize='small' />
                    </IconButton>
                    <div className={s.email}>
                        Email: {email}
                    </div>
                </span>}
                {!isAuth && <span className={s.guest}>
                    Hey, Guest!
                </span>}
                {errors ? <div className={s.error}>
                    {error}
                </div> : null}
                <div className={s.buttons}>
                    {isAuth && <Button onClick={async () => await authService.signOut()}>Logout </Button>}
                    {!isAuth && <Button onClick={async () => await authService.signIn()}>Login</Button>}
                </div>
            </div>
        }
        {isEdit &&
            <div className={s.info}>
                <input onChange={onNameChanged} autoFocus={true} onBlur={deactivateEditMode} value={name}></input>
            </div>
        }
    </div>
    );
}

export default ProfileInfo;