import React, { useState, useEffect } from 'react';
import s from './ProfileInfo.module.css';
import IconButton from '@mui/material/IconButton';
import EditIcon from '@mui/icons-material/Edit';
import authService, { useUser } from '../../../../Services/authService';
import { Button } from '@mui/material';
import { useAuthContext } from '../../../Auth/AuthProvider';

const ProfileInfo = props => {

    const { owner, editOwner } = props;

    const [isEdit, setIsEdit] = useState(false);
    const [name, setName] = useState(owner.fullName);

    const { isAuth } = useAuthContext();

    useEffect(() => {
        setName(owner.fullName);
    }, [owner.fullName]);

    const activateEditMode = () => {
        setIsEdit(true);
    };

    const deactivateEditMode = () => {
        setIsEdit(false);

        owner.fullName = name;
        editOwner(owner);
    };

    const onNameChanged = (e) => {
        setName(e.currentTarget.value);
    }

    return (<div className={s.wrapper}>
        {!isEdit &&
            <div className={s.info}>
                {isAuth && <span className={s.name}>
                    {owner.fullName}
                    <IconButton onClick={activateEditMode}>
                        <EditIcon fontSize='small' />
                    </IconButton>
                </span>}
                {!isAuth && <span className={s.guest}>
                    Hey, Guest!
                </span>}
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