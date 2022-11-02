import React from 'react';
import s from './NoContent.module.css'

type NoContentProps = {};

const NoContent : React.FC<NoContentProps> = (props) => {
    return (
        <div className={s.noContent}>No content provided yet.</div>
    );
}

export default NoContent;

