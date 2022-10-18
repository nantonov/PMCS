import React from "react";
import { reduxForm, Field } from "redux-form";
import s from "./petForm.module.css";
import { required } from "../../utils/validators";
import { Input } from "../Shared/FormsControls/Input";
import { useEffect, useState } from "react";

let AddReminderForm = ({ handleSubmit, error, submitSucceeded, pets }) => {
    const [isSuccess, setSuccess] = useState(false);

    let petsList = pets.map(pet => <option key={pet.id} value={pet.id}>{pet.name}</option>);

    useEffect(() => {
        setSuccess(submitSucceeded);
    }, []);

    return (
        <form className={s.formBox} onSubmit={handleSubmit}>
            <header>New reminder</header>
            <label>When to remind</label>
            <Field name={"triggerDateTime"} component={Input} type={"date"} validate={[required]} />
            <label>How to remind</label>
            <Field name="notificationType" component="select">
                <option value="0">Email</option>
                <option value="1">Account</option>
            </Field>
            <label>Remind to</label>
            <Field name="actionToRemindType" component="select">
                <option value="0">Make vaccine</option>
                <option value="1">Feed pet</option>
                <option value="2">Go for a walk</option>
            </Field>
            <label>Notification Message</label>
            <Field name={"notificationMessage"} component={Input} type={"textarea"} validate={[required]} />
            <label>For pet</label>
            <Field name="petId" component="select">
                {petsList}
            </Field>
            <button>Submit</button>
            {error ? <div className={s.error}>{error}</div> : null}
            {isSuccess && !error ? <div className={s.success}>You added reminder successfully!</div> : null}
        </form>
    );
}

const AddReminderReduxForm = reduxForm({ form: "addReminderForm" })(AddReminderForm);

export default AddReminderReduxForm;