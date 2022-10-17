import React from "react";
import { reduxForm, Field } from "redux-form";
import s from "./petForm.module.css";
import { required } from "../../utils/validators";
import {Input} from "../Shared/FormsControls/Input";
import { useEffect, useState } from "react";

let AddPetForm = ({ handleSubmit, error, submitSucceeded }) => {

    const [isSuccess, setSuccess] = useState(false);

    useEffect(() => {
        setSuccess(submitSucceeded);
    }, [pet]);

    return (
        <form className={s.formBox} onSubmit={handleSubmit}>
            <header>Add pet</header>
            <label>Name   </label>
            <Field name={"name"} component={Input} type={"text"} validate={[required]} />
            <label>Info</label>
            <Field name={"info"} component={Input} validate={[required]} />
            <label>Weight</label>
            <Field name={"weight"} component={Input} type={"number"} step={"0.1"} min={"0.1"} validate={[required]} />
            <label>Date of birth</label>
            <Field name={"birthDate"} component={Input} type={"date"} validate={[required]} />
            <button>Submit</button>
             {error ? <div className={s.error}>{error}</div> : null}
            {isSuccess && !error ? <div className={s.success}>You added your pet successfully!</div> : null}
        </form>
    );
}

const AddPetReduxForm = reduxForm({ form: "addPetForm" })(AddPetForm);

export default AddPetReduxForm;