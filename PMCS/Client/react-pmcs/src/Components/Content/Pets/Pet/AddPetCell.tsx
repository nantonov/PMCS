import React, { SetStateAction } from 'react';
import s from './AddPetCell.module.css'
import IconButton from '@mui/material/IconButton';
import AddCircleIcon from '@mui/icons-material/AddCircle';

type AddPetCellProps = {
    setAddModalOpen: React.Dispatch<SetStateAction<boolean>>
}

const AddPetCell: React.FC<AddPetCellProps> = ({ setAddModalOpen }) => {
    function handleClick() : void {
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