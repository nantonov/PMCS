import React from "react";
import { reduxForm, Field } from "redux-form";
import s from "./petForm.module.css";
import { required } from "../../utils/validators";
import { Input } from "../Shared/FormsControls/Input";
import { useEffect, useState } from "react";
import { NotificationType, ActionToRemindType } from "../../Enums/reminderEnums.ts";

let AddReminderForm = ({ handleSubmit, error, pets, submitSucceeded }) => {
    const [isSuccess, setSuccess] = useState(false);

    let petsList = pets.map(pet => <option key={pet.id} value={pet.id}>{pet.name}</option>);

    useEffect(() => {
        setSuccess(submitSucceeded);
    }, []);

    return (
        <form className={s.formBox} onSubmit={handleSubmit}>
            <header>New reminder</header>
            <label>When to remind</label>
            <Field name={"triggerDateTime"} component={Input} type={"datetime-local"} validate={[required]} />
            <label>How to remind</label>
            <Field name="notificationType" component="select">
                <option value={NotificationType.Email}>Email</option>
                <option value={NotificationType.PersonalAccount}>Account</option>
            </Field>
            <label>Remind to</label>
            <Field name="actionToRemindType" component="select">
                <option value={ActionToRemindType.MakeVaccine}>Make vaccine</option>
                <option value={ActionToRemindType.FeedPet}>Feed pet</option>
                <option value={ActionToRemindType.GoForWalk}>Go for a walk</option>
            </Field>
            <label>Notification Message</label>
            <Field name={"notificationMessage"} component={Input} type={"textarea"} validate={[required]} placeholder="Remind me to..." />
            <label>For pet</label>
            <Field name="petId" component="select">
                <option validate={[required]}></option>
                {petsList}
            </Field>
            <button>Submit</button>
            {error ? <div className={s.error}>{error}</div> : null}
            {isSuccess ? <div className={s.success}>You added reminder successfully!</div> : null}
        </form>
    );
}

const AddReminderReduxForm = reduxForm({ form: "addReminderForm" })(AddReminderForm);

export default AddReminderReduxForm;