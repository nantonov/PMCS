import { reduxForm, Field, InjectedFormProps } from "redux-form";
import { required } from "../../utils/validators";
import { Input } from "../Shared/FormsControls/Input";
import s from "./petForm.module.css";
import { NotificationType, ActionToRemindType } from "../../Enums/reminderEnums";
import { IUpdateReminderRequest } from "../../common/requests/Reminder/IUpdateReminderRequest";
import { Select } from "../Shared/FormsControls/Select";
import { EDIT_FORM } from "../../redux/Reminders/constants";

type FormProps = {}
type Props = InjectedFormProps<IUpdateReminderRequest, FormProps> & FormProps;

const EditReminderForm: React.FC<Props> = ({ handleSubmit, error, submitFailed }) => {

    return (
        <form className={s.formBox} onSubmit={handleSubmit}>
            <header>Edit reminder</header>
            <label>When to remind</label>
            <Field name={"triggerDateTime"} component={Input} type={"datetime-local"} validate={[required]} />
            <label>How to remind</label>
            <Field name="notificationType" component={Select} validate={[required]}>
                <option></option>
                <option value={NotificationType.Email}>Email</option>
                <option value={NotificationType.PersonalAccount}>Account</option>
            </Field>
            <label>Remind to</label>
            <Field name="actionToRemindType" component={Select} validate={[required]}>
                <option></option>
                <option value={ActionToRemindType.GoForWalk}>Go for a walk</option>
                <option value={ActionToRemindType.MakeVaccine}>Make vaccine</option>
                <option value={ActionToRemindType.FeedPet}>Feed pet</option>
            </Field>
            <label>Notification Message</label>
            <Field name={"notificationMessage"} component={Input} type={"textarea"} validate={[required]} placeholder="Remind me to..." />
            <button>Submit</button>
            {submitFailed ? <div className={s.error}>{error}</div> : null}
        </form>
    );
}

const EditReminderReduxForm = reduxForm<IUpdateReminderRequest, FormProps>({ form: EDIT_FORM })(EditReminderForm);

export default EditReminderReduxForm;