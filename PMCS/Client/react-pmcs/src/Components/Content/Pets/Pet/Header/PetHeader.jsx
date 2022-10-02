import React from 'react';
import s from './PetHeader.module.css'
import IconButton from '@mui/material/IconButton';
import Stack from '@mui/material/Stack';
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';

const PetHeader = (props) => {

    const {pet, deletePet, setEditModalOpen} = props;

    let onDeleteButtonClick = () => {
        let id = pet.id;
        deletePet(id);
    };

    let onEditButtonClick = () => {
       setEditModalOpen(true);
    };

    return (
    <header className={s.wrapper}>
        <div className={s.nameText}>
            {pet.name}
        </div>
        <div className={s.buttons}>
            <Stack direction="row" spacing={1}>
                <IconButton aria-label="edit" size="small" onClick={onEditButtonClick}>
                    <EditIcon fontSize='small' />
                </IconButton>
                <IconButton aria-label="delete" size="small" onClick={onDeleteButtonClick}>
                    <DeleteIcon />
                </IconButton>
            </Stack>
        </div>
    </header>
    );
}

export default PetHeader;

