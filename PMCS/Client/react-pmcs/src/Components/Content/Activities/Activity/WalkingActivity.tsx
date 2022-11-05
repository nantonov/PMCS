import React from 'react';
import s from './Activity.module.css'
import { IWalking } from '../../../../common/models/IWalking';

type WalkingProps = Omit<IWalking, "id">;

const WalkingActivity: React.FC<WalkingProps> = ({ stared, finished, title, description, pet }) => {
    return (
        <article className={s.item}>
            <div>
                Title: {title}
            </div>
            <div>
                Description: {description}
            </div>
            <div>
                Started: {stared}
            </div>
            <div>
                Finished: {finished}
            </div>
            <div>
                Pet name: {pet?.name}
            </div>
        </article>
    );
}

export default WalkingActivity;