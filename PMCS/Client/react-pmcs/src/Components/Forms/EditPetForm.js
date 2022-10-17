import React from "react";
import s from "./petForm.module.css";
import { Field, reduxForm } from "redux-form";
import { useEffect } from "react";

let EditPetForm = ({ handleSubmit, isSuccess, errors, pet, initialize }) => {
    
    useEffect(() => {
        initialize({
            name: pet.name,
            info: pet.info,
            weight: pet.weight,
            birthDate: pet.birthDate,
        });
    }, [pet]);

    return (
        <form className={s.formBox} onSubmit={handleSubmit}>
            <header>Edit pet</header>
            <label>Name   </label>
            <Field name={"name"} component={"input"} type={"text"} required />
            <label>Info</label>
            <Field name={"info"} component={"textarea"} required />
            <label>Weight</label>
            <Field name={"weight"} component={"input"} type={"number"} step={"0.1"} min={"0.1"} required />
            <button type="submit">Submit</button>
            {!isSuccess ? <div className={s.error}>{errors}</div> : null}
            {isSuccess ? <div className={s.success}>You edited your pet successfully!</div> : null}
        </form>
    );
}

const EditPetReduxForm = reduxForm({ form: "editPetForm" })(EditPetForm);

export default EditPetReduxForm;