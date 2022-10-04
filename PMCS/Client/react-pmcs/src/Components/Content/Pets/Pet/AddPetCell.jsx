import React, { useState } from 'react';
import s from './AddPetCell.module.css'
import IconButton from '@mui/material/IconButton';
import AddCircleIcon from '@mui/icons-material/AddCircle';

const AddPetCell = props => {
    return (
        <article className={s.item}>
            <span>Add new pet</span>
            <IconButton onClick={props.setAddModalOpen} className={s.button}>
                <AddCircleIcon className={s.icon} />
            </IconButton>
        </article>
    );
}

export default AddPetCell;