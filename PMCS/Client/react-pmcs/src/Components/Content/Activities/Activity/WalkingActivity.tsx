import React, { SetStateAction } from 'react';
import s from './Activity.module.css'
import { IWalking } from '../../../../common/models/IWalking';
import Button from '@mui/material/Button';
import DeleteIcon from '@mui/icons-material/Delete';
import { deleteWalking } from '../../../../redux/Activities/walkingActionCreators';

type WalkingProps = {
    walking: IWalking,
    deleteWalking: typeof deleteWalking,
    setWalkingDeleted: React.Dispatch<SetStateAction<boolean>>
};

const WalkingActivity: React.FC<WalkingProps> = ({ walking, setWalkingDeleted, deleteWalking }) => {
    const [deletedFlag, toggleDeletedFlag] = React.useState(true);

    const handleDeleteButtonClick = () => {
        deleteWalking(walking.id);
        setWalkingDeleted(deletedFlag);
        toggleDeletedFlag(!deletedFlag);
    }

    return (
        <article className={s.item}>
            <div>
                <span className={s.strong}>Title:</span> {walking.title}
            </div>
            <div>
                <span className={s.strong}>Description:</span> {walking.description}
            </div>
            <div>
                <span className={s.strong}>Started:</span> {walking.stared}
            </div>
            <div>
                <span className={s.strong}>Finished:</span> {walking.finished}
            </div>
            <div>
                <span className={s.strong}> Pet name:</span> {walking.pet?.name}
            </div>
            <Button onClick={handleDeleteButtonClick} startIcon={<DeleteIcon />} color="error" className={s.deleteButton}>
                Delete
            </Button>
        </article>
    );
}

export default WalkingActivity;