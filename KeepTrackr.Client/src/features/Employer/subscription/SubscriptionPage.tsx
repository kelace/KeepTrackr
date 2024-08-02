import React, { useEffect, useState, MouseEvent, HtmlHTMLAttributes } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { AppDispatch } from '../../../app/store';
import { fetchAllSubscriptions, changeType, submitChange, Subscription } from './SubscriptionSlice';
import CircularProgress from '@mui//material/CircularProgress';
import Button from '@mui//material/Button';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import Grid from '@mui/material/Grid';
import Typography from '@mui/material/Typography';

function SubscriptionPage() {
    const dispatch = useDispatch<AppDispatch>();
    const subscriptions = useSelector((x: any) => x.subscription.subscriptions);
    const loading = useSelector((x: any) => x.subscription.loading);
    const choosedSubscription = useSelector((x: any) => x.subscription.choosedSubscription);
    const initialType = useSelector((x: any) => {
        const sub = x.subscription.subscriptions.find((el: Subscription) => el.isSubscribed);
        return sub ? sub.type : '';
    });

    const changeSubscriptionHandler = (type: any) => (e: MouseEvent<HTMLElement>) => {
        dispatch(changeType(type));
    }

    const submitHandler = (e: MouseEvent<HTMLElement>) => {
        e.preventDefault();


        if (choosedSubscription == initialType) return;

        dispatch(submitChange(choosedSubscription));
    }

    useEffect(() => {

        dispatch(fetchAllSubscriptions());

    }, []);

    const subscriptionsElements =
        subscriptions.map((x: any) => {
            let isChoosed = choosedSubscription == '' && x.isSubscribed;

            if (choosedSubscription == x.type) isChoosed = true;

            return (

                <Grid item xs={3} style={{ marginBottom: "30px" }} >
                    <Card sx={{ minWidth: 275 }} onClick={changeSubscriptionHandler(x.type)} style={{ border: '1px solid white', borderColor: isChoosed ? 'green' : 'white', cursor: 'pointer' }}>
                            <CardContent>
                                <Typography sx={{ fontSize: 14 }} color="text.secondary" gutterBottom>
                                    Word of the Day
                                </Typography>
                                <Typography variant="h5" component="div">
                                    {x.type}
                                </Typography>
                                <Typography sx={{ mb: 1.5 }} color="text.secondary">
                                    adjective
                                </Typography>
                                <Typography variant="body2">
                                    well meaning and kindly.
                                    <br />
                                    {'"a benevolent smile"'}
                                </Typography>
                            </CardContent>
                            <CardActions>
                                <Button size="small">Learn More</Button>
                            </CardActions>
                        </Card>
                </Grid>
            )
        });

    return (
        <div>
            {loading ? <CircularProgress /> : <Grid container spacing={2} justifyContent="center"> {subscriptionsElements} </Grid> }
            <Button variant="outlined" onClick={submitHandler}> Change </Button>
        </div>
    );
}

export default SubscriptionPage;