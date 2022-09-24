import React from 'react';
import s from './LastActivityList.module.css';
import LastActivity from './LastActivity/LastActivity';
import Button from '@mui/material/Button';
import VisibilityOutlinedIcon from '@mui/icons-material/VisibilityOutlined';

const LastActivityList = (props) => {
    return (
        <article className={s.wrapper}>
            <div className={s.title}>Last activities</div>
            <div className={s.list}>
                <LastActivity item={props.activities[0]} />
                <LastActivity item={props.activities[1]} />
                <LastActivity item={props.activities[2]} />
            </div>
            <Button color='info' startIcon={<VisibilityOutlinedIcon />} className={s.showButton}>
                <span className={s.text}>Show all info</span>
            </Button>
        </article>
    );
}

export default LastActivityList;