import React from "react";
import s from './FormControls.module.css';

export const Input = ({ input, meta, ...props }) => {
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