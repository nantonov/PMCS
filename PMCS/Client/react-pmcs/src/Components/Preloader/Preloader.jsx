import { CircularProgress } from '@mui/material';
import s from './Preloader.module.css';

const Preloader = (props) => {
    return (
        <div className={s.wrapper}>
            <CircularProgress />
        </div>
    );
}

export default Preloader;