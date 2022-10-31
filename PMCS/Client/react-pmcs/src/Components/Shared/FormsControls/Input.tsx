import React from "react";
import { WrappedFieldInputProps, WrappedFieldMetaProps } from "redux-form";
import s from './FormControls.module.css';

type Props = {
    meta: WrappedFieldMetaProps;
    children: React.ReactNode;
    input: WrappedFieldInputProps;
}

export const Input: React.FC<Props> = ({ input, meta, ...props }) => {
    const hasError = meta.touched && meta.error;
    return (
        <div>
            <div>
                <input {...input} {...props} />
            </div>
            {hasError && <span className={s.error}>{meta.error}</span>}
        </div>
    );
}