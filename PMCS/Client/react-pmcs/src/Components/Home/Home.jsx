import React from 'react';
import s from './Home.module.css';
import { useAuthContext } from '../Auth/AuthProvider';

const Home = props => {
    const { isAuth } = useAuthContext();

    return (
        <section className={s.wrapper}>
            <h1>Home</h1>
            {isAuth &&  <div className={s.text}>
                Hello, welcome to Pets Monitoring and Control System main page!
            </div>}
           {!isAuth && <div className={s.text}>You are not authenticated. Please, login.</div>}
        </section>
    );
}

export default Home;