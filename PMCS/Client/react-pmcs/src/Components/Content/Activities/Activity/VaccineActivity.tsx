import React, { SetStateAction } from 'react';
import s from './Activity.module.css'
import { IVaccine } from '../../../../common/models/IVaccine';
import Button from '@mui/material/Button';
import DeleteIcon from '@mui/icons-material/Delete';
import { deleteVaccine } from '../../../../redux/Activities/vaccineActionCreators';

type VaccineProps = {
    vaccine: IVaccine,
    deleteVaccine: typeof deleteVaccine,
    setVaccineDeleted: React.Dispatch<SetStateAction<boolean>>
};

const VaccineActivity: React.FC<VaccineProps> = ({ vaccine, setVaccineDeleted, deleteVaccine }) => {
    const [deletedFlag, toggleDeletedFlag] = React.useState(true);

    const handleDeleteButtonClick = () => {
        deleteVaccine(vaccine.id);
        setVaccineDeleted(deletedFlag);
        toggleDeletedFlag(!deletedFlag);
    }

    return (
        <article className={s.item}>
            <div>
                <span className={s.strong}>Title:</span> {vaccine.title}
            </div>
            <div>
                <span className={s.strong}>Description:</span> {vaccine.description}
            </div>
            <div>
                <span className={s.strong}>DateTime:</span> {vaccine.dateTime}
            </div>
            <div>
                <span className={s.strong}>Pet name:</span> {vaccine.pet?.name}
            </div>
            <Button onClick={handleDeleteButtonClick} startIcon={<DeleteIcon />} color="error" className={s.deleteButton}>
                Delete
            </Button>
        </article>
    );
}

export default VaccineActivity;