import React from 'react';
type ActivitiesProps = {
    children: React.ReactNode | React.ReactNode[];
}

const Activities: React.FC<ActivitiesProps> = ({ children }) => {
    return (
        <>
            {children}
        </>
    );
}

export default Activities;