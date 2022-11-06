import React, { SetStateAction } from 'react';
import s from './Activity.module.css'
import { IMeal } from '../../../../common/models/IMeal';
import Button from '@mui/material/Button';
import DeleteIcon from '@mui/icons-material/Delete';
import { deleteMeal } from '../../../../redux/Activities/mealActionCreators';

type MealProps = {
    meal: IMeal,
    deleteMeal: typeof deleteMeal,
    setMealDeleted: React.Dispatch<SetStateAction<boolean>>
};

const MealActivity: React.FC<MealProps> = ({ meal, deleteMeal, setMealDeleted }) => {

    const [deletedFlag, toggleDeletedFlag] = React.useState(true);

    const handleDeleteButtonClick = () => {
        deleteMeal(meal.id);
        setMealDeleted(deletedFlag);
        toggleDeletedFlag(!deletedFlag);
    }

    return (
        <article className={s.item}>
            <div>
                <span className={s.strong}>Title:</span> {meal.title}
            </div>
            <div>
                <span className={s.strong}>Description:</span> {meal.description}
            </div>
            <div>
                <span className={s.strong}>DateTime:</span> {meal.dateTime}
            </div>
            <div>
                <span className={s.strong}>Pet name:</span> {meal.pet?.name}
            </div>
            <Button onClick={handleDeleteButtonClick} startIcon={<DeleteIcon />} color="error" className={s.deleteButton}>
                Delete
            </Button>
        </article>
    );
}

export default MealActivity;