import React from 'react';
import s from './Activity.module.css'
import { IVaccine } from '../../../../common/models/IVaccine';
import Button from '@mui/material/Button';
import DeleteIcon from '@mui/icons-material/Delete';
import { deleteVaccine } from '../../../../redux/Activities/vaccineActionCreators';

type VaccineProps = IVaccine & {deleteVaccine: typeof deleteVaccine};

const VaccineActivity: React.FC<VaccineProps> = ({ dateTime, title, description, pet, id, deleteVaccine }) => {
    const handleDeleteButtonClick = () => deleteVaccine(id);
    return (
        <article className={s.item}>
            <div>
                <span className={s.strong}>Title:</span> {title}
            </div>
            <div>
                <span className={s.strong}>Description:</span> {description}
            </div>
            <div>
                <span className={s.strong}>DateTime:</span> {dateTime}
            </div>
            <div>
                <span className={s.strong}>Pet name:</span> {pet?.name}
            </div>
            <Button onClick={handleDeleteButtonClick} startIcon={<DeleteIcon />} color="error" className={s.deleteButton}>
                Delete
            </Button>
        </article>
    );
}

export default VaccineActivity;