import React from 'react';
import s from './Content.module.css'
import Pet from './Pet/Pet';

let pet = { name: "Johny", info: "Very funny pet.", birthdate: "12/05/2012", weight: "5kg" };

const Content = () => {
    return (
        <main className={s.content}>
            <Pet pet={pet}/>
            <Pet pet={pet}/>
        </main>
    );
}

export default Content;