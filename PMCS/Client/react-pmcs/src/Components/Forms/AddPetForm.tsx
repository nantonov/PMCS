import React from "react";
import { reduxForm, Field, InjectedFormProps } from "redux-form";
import s from "./petForm.module.css";
import { required } from "../../utils/validators";
import { Input } from "../Shared/FormsControls/Input";
import { ICreatePetRequest } from "../../common/requests/Pet/ICreatePetRequest";

type FormProps = {};
type Props = InjectedFormProps<ICreatePetRequest, FormProps> & FormProps;

let AddPetForm: React.FC<Props> = ({ handleSubmit, error, submitFailed }) => {
    return (
        <form className={s.formBox} onSubmit={handleSubmit}>
            <header>Add pet</header>
            <label>Name   </label>
            <Field name={"name"} component={Input} type={"text"} validate={[required]} />
            <label>Info</label>
            <Field name={"info"} component={Input} />
            <label>Weight</label>
            <Field name={"weight"} component={Input} type={"number"} step={"0.1"} min={"0.1"} validate={[required]} />
            <label>Date of birth</label>
            <Field name={"birthDate"} component={Input} type={"date"} validate={[required]} />
            <button>Submit</button>
            {submitFailed ? <div className={s.error}>{error}</div> : null}
        </form>
    );
}

const AddPetReduxForm = reduxForm<ICreatePetRequest, FormProps>({ form: "addPetForm" })(AddPetForm);

export default AddPetReduxForm;