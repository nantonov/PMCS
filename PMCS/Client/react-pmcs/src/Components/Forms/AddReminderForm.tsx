import React from "react";
import { reduxForm, Field, InjectedFormProps } from "redux-form";
import s from "./petForm.module.css";
import { required } from "../../utils/validators";
import { Input } from "../Shared/FormsControls/Input";
import { NotificationType, ActionToRemindType } from "../../Enums/reminderEnums";
import { ICreateReminderRequest } from "../../common/requests/Reminder/ICreateReminderRequest";
import { IPet } from "../../common/models/IPet";
import { fetchPets } from "../../redux/Pets/actionCreators";
import { Select } from "../Shared/FormsControls/Select";
import { ADD_FORM } from "../../redux/Reminders/constants";

type FormProps = {
    pets: Array<IPet>,
    fetchPets: typeof fetchPets
}
type Props = InjectedFormProps<ICreateReminderRequest, FormProps> & FormProps;

let AddReminderForm: React.FC<Props> = ({ handleSubmit, error, pets, submitFailed, fetchPets }) => {
    let petsList = pets.map(pet => <option key={pet.id} value={pet.id}>{pet.name}</option>);

    return (
        <form className={s.formBox} onSubmit={handleSubmit}>
            <header>New reminder</header>
            <label>When to remind</label>
            <Field name={"triggerDateTime"} component={Input} type={"datetime-local"} validate={[required]} />
            <label>How to remind</label>
            <Field name="notificationType" component={Select} validate={[required]}>
                <option ></option>
                <option value={NotificationType.Email}>Email</option>
                <option value={NotificationType.PersonalAccount}>Account</option>
            </Field>
            <label>Remind to</label>
            <Field name="actionToRemindType" component={Select} validate={[required]}>
                <option ></option>
                <option value={ActionToRemindType.MakeVaccine}>Make vaccine</option>
                <option value={ActionToRemindType.FeedPet}>Feed pet</option>
                <option value={ActionToRemindType.GoForWalk}>Go for a walk</option>
            </Field>
            <label>Notification Message</label>
            <Field name={"notificationMessage"} component={Input} type={"textarea"} validate={[required]} placeholder="Remind me to..." />
            <label>For pet</label>
            <Field name="petId" component={Select} onFocus={fetchPets} validate={[required]}>
                <option></option>
                {petsList}
            </Field>
            <button>Submit</button>
            {submitFailed ? <div className={s.error}>{error}</div> : null}
        </form>
    );
}

const AddReminderReduxForm = reduxForm<ICreateReminderRequest, FormProps>({ form: ADD_FORM })(AddReminderForm);

export default AddReminderReduxForm;