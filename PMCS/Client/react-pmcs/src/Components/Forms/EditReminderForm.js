import React from "react";
import { reduxForm, Field } from "redux-form";
import s from "./petForm.module.css";
import { required } from "../../utils/validators";
import { Input } from "../Shared/FormsControls/Input";
import { useEffect, useState } from "react";
import { NotificationType, ActionToRemindType } from "../../Enums/reminderEnums.ts";

let EditReminderForm = ({ handleSubmit, error, submitSucceeded, reminder, initialize }) => {
    const [isSuccess, setSuccess] = useState(false);

    useEffect(() => {
        setSuccess(submitSucceeded);
    }, [reminder]);

    useEffect(() => {
        initialize({
            triggerDateTime: reminder.triggerDateTime,
            notificationMessage: reminder.notificationMessage,
            actionToRemindType: reminder.actionToRemindType,
            notificationType: reminder.notificationType,
        });
    }, [reminder]);

    return (
        <form className={s.formBox} onSubmit={handleSubmit}>
            <header>Edit reminder</header>
            <label>When to remind</label>
            <Field name={"triggerDateTime"} component={Input} type={"datetime-local"} validate={[required]} />
            <label>How to remind</label>
            <Field name="notificationType" component={"select"} >
                <option value={NotificationType.Email}>Email</option>
                <option value={NotificationType.PersonalAccount}>Account</option>
            </Field>
            <label>Remind to</label>
            <Field name="actionToRemindType" component="select" >
                <option value={ActionToRemindType.GoForWalk}>Go for a walk</option>
                <option value={ActionToRemindType.MakeVaccine}>Make vaccine</option>
                <option value={ActionToRemindType.FeedPet}>Feed pet</option>
            </Field>
            <label>Notification Message</label>
            <Field name={"notificationMessage"} component={Input} type={"textarea"} validate={[required]} placeholder="Remind me to..." />
            <button>Submit</button>
            {error ? <div className={s.error}>{error}</div> : null}
            {isSuccess && !error ? <div className={s.success}>You edited reminder successfully!</div> : null}
        </form>
    );
}

const EditReminderReduxForm = reduxForm({ form: "editReminderForm" })(EditReminderForm);

export default EditReminderReduxForm;