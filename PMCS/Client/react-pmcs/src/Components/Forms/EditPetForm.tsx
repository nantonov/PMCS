import React from "react";
import { InjectedFormProps } from "redux-form";
import s from "./petForm.module.css";
import { Field, reduxForm } from "redux-form";
import { useEffect, useState } from "react";
import { Input } from "../Shared/FormsControls/Input";
import { required } from "../../utils/validators";
import { IUpdatePetRequest } from "../../common/requests/Pet/IUpdatePetRequest";

type FormProps = {
    pet: IUpdatePetRequest;
}
type Props = InjectedFormProps<IUpdatePetRequest, FormProps> & FormProps;

let EditPetForm : React.FC<Props> = ({ handleSubmit, error, pet, initialize, submitSucceeded }) => {

    const [isSuccess, setSuccess] = useState(false);

    useEffect(() => {
        setSuccess(submitSucceeded);
    }, [pet]);

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
            <Field name={"info"} component={Input} validate={[required]} />
            <label>Weight</label>
            <Field name={"weight"} component={Input} type={"number"} step={"0.1"} min={"0.1"} validate={[required]} />
            <button>Submit</button>
            {error ? <div className={s.error}>{error}</div> : null}
            {isSuccess && !error ? <div className={s.success}>You edited your pet successfully!</div> : null}
        </form>
    );
}

const EditPetReduxForm = reduxForm<IUpdatePetRequest, FormProps>({ form: "editPetForm" })(EditPetForm);

export default EditPetReduxForm;