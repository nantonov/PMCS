import * as React from 'react';
import CircularProgress, { CircularProgressProps } from '@mui/material/CircularProgress';
import Typography from '@mui/material/Typography';
import Box from '@mui/material/Box';
import { circularBarSxProps } from './sxProps';

type Props = { value: number; } & CircularProgressProps;

const CircularProgressWithLabel: React.FC<Props> = (props) => {
    return (
        <Box sx={{ position: 'relative', display: 'inline-flex' }}>
            <CircularProgress variant="determinate" {...props} />
            <Box sx={circularBarSxProps}>
                <Typography variant="subtitle1" component="div" color="text.secondary" >
                    {`${props.value}%`}
                </Typography>
            </Box>
        </Box>
    );
}

export default CircularProgressWithLabel;