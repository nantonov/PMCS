import React from "react";
import { reduxForm, Field, InjectedFormProps } from "redux-form";
import s from "./petForm.module.css";
import { required } from "../../utils/validators";
import { Input } from "../Shared/FormsControls/Input";
import { ICreateActivityRequest } from "../../common/requests/Activities/ICreateActivityRequest";
import { ActivityType } from "../../Enums/activityEnums";
import { IPet } from "../../common/models/IPet";
import { ADD_FORM } from "../../redux/Activities/constants";
import { Select } from "../Shared/FormsControls/Select";

type FormProps = {
    pets: Array<IPet>,
    fetchPets: () => void
};
type Props = InjectedFormProps<ICreateActivityRequest, FormProps> & FormProps;

let AddActivityForm: React.FC<Props> = ({ handleSubmit, error, pets, submitFailed, fetchPets }) => {

    let petsList = pets.map(pet => <option key={pet.id} value={pet.id}>{pet.name}</option>);

    return (
        <form className={s.formBox} onSubmit={handleSubmit}>
            <header>Add activity</header>
            <label>Title   </label>
            <Field name={"title"} component={Input} type={"text"} validate={[required]} />
            <label>Description</label>
            <Field name={"description"} component={Input} validate={[required]} />
            <label>DateTime</label>
            <Field name={"dateTime"} component={Input} type={"datetime-local"} validate={[required]} />
            <Field name="activityType" component={Select} validate={[required]}>
                <option></option>
                <option value={ActivityType.Vaccine}>Vaccine</option>
                <option value={ActivityType.Meal}>Meal</option>
                <option value={ActivityType.Walking}>Walking</option>
            </Field>
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

const AddActivityReduxForm = reduxForm<ICreateActivityRequest, FormProps>({ form: ADD_FORM })(AddActivityForm);

export default AddActivityReduxForm;