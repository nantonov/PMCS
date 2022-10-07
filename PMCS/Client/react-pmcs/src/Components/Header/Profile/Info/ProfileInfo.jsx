import React, { useState, useEffect } from 'react';
import s from './ProfileInfo.module.css';
import IconButton from '@mui/material/IconButton';
import EditIcon from '@mui/icons-material/Edit';

const ProfileInfo = props => {

    const { owner, editOwner} = props;

    const [isEdit, setIsEdit] = useState(false);
    const [name, setName] = useState(owner.fullName);

    useEffect(() => {
        setName(owner.fullName);
    },[owner.fullName]);

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

    return (<div>
        {!isEdit &&
            <div className={s.info}>
                <span>{owner.fullName}</span>
                <IconButton onClick={activateEditMode}>
                        <EditIcon fontSize='small' />
                </IconButton>
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