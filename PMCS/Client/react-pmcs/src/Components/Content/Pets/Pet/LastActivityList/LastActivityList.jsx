import React from 'react';
import s from './LastActivityList.module.css';
import LastActivity from './LastActivity/LastActivity';
import Button from '@mui/material/Button';
import VisibilityOutlinedIcon from '@mui/icons-material/VisibilityOutlined';

const LastActivityList = props => {
    const {pet} = props;

    let walkingElelement = pet.walkings.map(activityItem => <LastActivity date={activityItem.stared} key = {activityItem.id} name={"Walking"}/>);
    let mealElelement = pet.meals.map(activityItem => <LastActivity date={activityItem.dateTime} key = {activityItem.id} name={"Meal"}/>);
    let vaccineElelement = pet.vaccines.map(activityItem => <LastActivity date={activityItem.dateTime} key = {activityItem.id} name={"Vaccine"}/>);

    return (
        <article className={s.wrapper}>
            <div className={s.title}>Last activities</div>
            <div className={s.list}>
            {walkingElelement}
            {mealElelement}
            {vaccineElelement}
            </div>
            <Button color='info' startIcon={<VisibilityOutlinedIcon />} className={s.showButton}>
                <span className={s.text}>Show all info</span>
            </Button>
        </article>
    );
}

export default LastActivityList;