import React from 'react';
import s from './LastActivityList.module.css';
import LastActivity from './LastActivity/LastActivity';
import Button from '@mui/material/Button';
import VisibilityOutlinedIcon from '@mui/icons-material/VisibilityOutlined';

const LastActivityList = props => {
    const { pet, setInfoModalOpened } = props;

    let walkingElelement = pet.walkings.map(activityItem => <LastActivity date={activityItem.stared} name={"Walking"} />);
    let mealElelement = pet.meals.map(activityItem => <LastActivity date={activityItem.dateTime} name={"Meal"} />);
    let vaccineElelement = pet.vaccines.map(activityItem => <LastActivity date={activityItem.dateTime} name={"Vaccine"} />);
    
    let onShowInfoClick = () => {
        setInfoModalOpened(true);
    };

    return (
        <article className={s.wrapper}>
            <div className={s.title}>Last activities</div>
            <div className={s.list}>
                {walkingElelement[0]}
                {mealElelement[0]}
                {vaccineElelement[0]}
            </div>
            <Button color='info' startIcon={<VisibilityOutlinedIcon />} className={s.showButton} onClick={onShowInfoClick}>
                <span className={s.text}>Show all info</span>
            </Button>
        </article>
    );
}

export default LastActivityList;