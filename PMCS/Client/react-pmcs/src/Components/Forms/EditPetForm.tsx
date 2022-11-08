import React, {useEffect, useState} from "react";
import { InjectedFormProps } from "redux-form";
import s from "./petForm.module.css";
import { Field, reduxForm } from "redux-form";
import { Input } from "../Shared/FormsControls/Input";
import { required } from "../../utils/validators";
import { IUpdatePetRequest } from "../../common/requests/Pet/IUpdatePetRequest";
import { EDIT_FORM } from "../../redux/Pets/constants";

type FormProps = {
    pet: IUpdatePetRequest;
}
type Props = InjectedFormProps<IUpdatePetRequest, FormProps> & FormProps;

let EditPetForm : React.FC<Props> = ({ handleSubmit, error, pet, initialize, submitFailed }) => {
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
            <Field name={"name"} component={Input} type={"text"} validate={[required]} />
            <label>Info</label>
            <Field name={"info"} component={Input} />
            <label>Weight</label>
            <Field name={"weight"} component={Input} type={"number"} step={"0.1"} min={"0.1"} validate={[required]} />
            <button>Submit</button>
            {submitFailed ? <div className={s.error}>{error}</div> : null}
        </form>
    );
}

const EditPetReduxForm = reduxForm<IUpdatePetRequest, FormProps>({ form: EDIT_FORM })(EditPetForm);

export default EditPetReduxForm;