import React from 'react';
import s from './Pet.module.css'
import Button from '@mui/material/Button';
import VisibilityOutlinedIcon from '@mui/icons-material/VisibilityOutlined';
import LastActivity from './LastActivity/LastActivity';
import IconButton from '@mui/material/IconButton';
import Stack from '@mui/material/Stack';
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';

let walking = { name: "Walking", date: "12.12.2021 21:18" };
let meal = { name: "Meal", date: "12.12.2021 21:18" };
let vaccine = { name: "Vaccine", date: "12.12.2021 21:18" };

const Pet = (props) => {
    return (
        <section className={s.item}>
            <div className={s.name}>
                <div className={s.nameText}>
                    {props.pet.name} &#9733;
                </div>
                <div className={s.buttons}>
                    <Stack direction="row" spacing={1}>
                        <IconButton aria-label="edit" size="small">
                            <EditIcon fontSize='small'/>
                        </IconButton>
                        <IconButton aria-label="delete" size="small">
                            <DeleteIcon />
                        </IconButton>
                    </Stack>
                </div>
            </div>
            <div className={s.info}>
                {props.pet.info}
            </div>
            <div className={s.birth}>
                Birth Date: {props.pet.birthdate}
            </div>
            <div className={s.weight}>
                Weight: {props.pet.weight}
            </div>
            <Button color='info' startIcon={<VisibilityOutlinedIcon />} className={s.showButton}>
                <span className={s.text}>Show all info</span>
            </Button>
            <article className={s.activities}>
                <span className={s.title}>Last activities</span>
                <LastActivity item={walking} />
                <LastActivity item={meal} />
                <LastActivity item={vaccine} />
            </article>
        </section>
    );
}

export default Pet;