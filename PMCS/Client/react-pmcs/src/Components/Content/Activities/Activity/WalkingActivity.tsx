import React, { SetStateAction } from 'react';
import s from './Activity.module.css'
import { IWalking } from '../../../../common/models/IWalking';
import Button from '@mui/material/Button';
import DeleteIcon from '@mui/icons-material/Delete';
import { deleteWalking } from '../../../../redux/Activities/walkingActionCreators';

type WalkingProps = IWalking & { deleteWalking: typeof deleteWalking, setWalkingDeleted: React.Dispatch<SetStateAction<boolean>> };

const WalkingActivity: React.FC<WalkingProps> = ({ stared, finished, title, description, pet, id, setWalkingDeleted, deleteWalking }) => {

    const [deletedFlag, toggleDeletedFlag] = React.useState(true);

    const handleDeleteButtonClick = () => {
        deleteWalking(id);
        setWalkingDeleted(deletedFlag);
        toggleDeletedFlag(!deletedFlag);
    }

    return (
        <article className={s.item}>
            <div>
                <span className={s.strong}>Title:</span> {title}
            </div>
            <div>
                <span className={s.strong}>Description:</span> {description}
            </div>
            <div>
                <span className={s.strong}>Started:</span> {stared}
            </div>
            <div>
                <span className={s.strong}>Finished:</span> {finished}
            </div>
            <div>
                <span className={s.strong}> Pet name:</span> {pet?.name}
            </div>
            <Button onClick={handleDeleteButtonClick} startIcon={<DeleteIcon />} color="error" className={s.deleteButton}>
                Delete
            </Button>
        </article>
    );
}

export default WalkingActivity;