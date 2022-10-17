import React, { useState } from 'react';
import s from './AddPetCell.module.css'
import IconButton from '@mui/material/IconButton';
import AddCircleIcon from '@mui/icons-material/AddCircle';

const AddPetCell = ({setAddModalOpen}) => {
    function handleClick() {
        setAddModalOpen(true);
    };

    return (
        <article className={s.item}>
            <span>Add new pet</span>
            <IconButton onClick={handleClick} className={s.button}>
                <AddCircleIcon className={s.icon} />
            </IconButton>
        </article>
    );
}

export default AddPetCell;