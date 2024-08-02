import { createSlice, createAsyncThunk } from '@reduxjs/toolkit'
import httpClient from '../../../app/httpClient';
import { AxiosResponse } from 'axios';
import { useSelector } from 'react-redux';



export interface Subscription {
    type: string,
    isSubscribed: boolean
};

export const submitChange = createAsyncThunk('submitSubscriptionChange', async (choosedType : any) => {

    const token = localStorage.getItem('token');

    const config = {
        headers: {
            Authorization: `Bearer ${token}`
        }
    };

    const result = await httpClient.put('api/subscriptions', { type: choosedType } , config);

    return result.data;
});

export const fetchAllSubscriptions = createAsyncThunk('fetchSubscriptions', async () => {

    const token = localStorage.getItem('token');

    const config = {
        headers: {
            Authorization: `Bearer ${token}`
        }
    };

    const result: AxiosResponse<Subscription[]> = await httpClient.get('api/subscriptions', config);

    return result.data;
});

const slice = createSlice({
    name: 'subscription',
    reducers: {
        clear: (state: any) => {
            state.loading = false;
            state.choosedSubscription = '';
        },
        changeType: (state: any, action: any) => {
            state.choosedSubscription = action.payload;
        }

    },
    initialState: {
        choosedSubscription: '',
        loading: false,
        subscriptions: []
    },
    extraReducers(builder) {

        builder.addCase(fetchAllSubscriptions.pending, (state: any, action: any) => {
            state.loading = true;
        });

        builder.addCase(fetchAllSubscriptions.fulfilled, (state: any, action: any) => {
            state.subscriptions = action.payload;
            state.loading = false;
        });

        builder.addCase(submitChange.fulfilled, (state: any, action: any) => {
            state.subscriptions = state.subscriptions.map((el: any) => {
                if (el.isSubscribed) el.isSubscribed = false;
                if (el.type == action.payload.type) el.isSubscribed = true;
                return el;
            } );
        });
    }
});

export default slice.reducer;
export const { clear, changeType } = slice.actions;