import { CircularProgress } from '@mui/material';
import React from 'react';
import s from './Preloader.module.css';

const Preloader: React.FC = () => {
    return (
        <div className={s.wrapper}>
            <CircularProgress />
        </div>
    );
}

export default Preloader;