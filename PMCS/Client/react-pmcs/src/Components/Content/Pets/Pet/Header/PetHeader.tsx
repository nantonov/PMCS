import React, { SetStateAction } from 'react';
import s from './PetHeader.module.css'
import IconButton from '@mui/material/IconButton';
import Stack from '@mui/material/Stack';
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';
import { IPet } from '../../../../../common/models/IPet';
import { deletePet } from '../../../../../redux/Pets/actionCreators'

type PetHeaderProps = {
    pet: IPet,
    setEditModalOpen: React.Dispatch<SetStateAction<boolean>>,
    setIsPetDeleted: React.Dispatch<SetStateAction<boolean>>,
    deletePet: typeof deletePet;
}

const PetHeader: React.FC<PetHeaderProps> = ({ pet, deletePet, setEditModalOpen, setIsPetDeleted }) => {
    let onDeleteButtonClick = (): void => {
        let id = pet.id;
        deletePet(id);
        setIsPetDeleted(true);
    };

    let onEditButtonClick = (): void => {
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

