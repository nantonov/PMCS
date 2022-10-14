import React from 'react';
import s from './LastActivityList.module.css';
import LastActivity from './LastActivity/LastActivity';
import Button from '@mui/material/Button';
import VisibilityOutlinedIcon from '@mui/icons-material/VisibilityOutlined';

const LastActivityList = props => {
    const { pet, setInfoModalOpened } = props;

    let walkingElelement = pet.walkings.map(activityItem => <LastActivity activity={{dateTime:activityItem.dateTime}} />);
    let mealElelement = pet.meals.map(activityItem => <LastActivity activity={{dateTime:activityItem.dateTime}} />);
    let vaccineElelement = pet.vaccines.map(activityItem => <LastActivity activity={{dateTime:activityItem.dateTime}} />);
    
    let onShowInfoClick = () => {
        setInfoModalOpened(true);
    };

    return (
        <article className={s.wrapper}>
            <div className={s.title}>Last activities</div>
            <div className={s.list}>
                <div className={s.name}>Walkings</div>
                {!walkingElelement[0] && <div className={s.noActivity}>No activity</div>}
                {walkingElelement[0]}
                <div className={s.name}>Meals</div>
                {!mealElelement[0] && <div className={s.noActivity}>No activity</div>}
                {mealElelement[0]}
                <div className={s.name}>Vaccines</div>
                {!vaccineElelement[0] && <div className={s.noActivity}>No activity</div>}
                {vaccineElelement[0]}
            </div>
            <Button color='info' startIcon={<VisibilityOutlinedIcon />} className={s.showButton} onClick={onShowInfoClick}>
                <span className={s.text}>Show all info</span>
            </Button>
        </article>
    );
}

export default LastActivityList;