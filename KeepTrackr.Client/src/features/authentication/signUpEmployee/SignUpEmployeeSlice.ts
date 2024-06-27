import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import httpClient from '../../../app/httpClient';

export const signUpEmployee = createAsyncThunk('signUpEmployee/signUp', async (employee: any) => {

    const config = {
        headers: {
            Authorization: `Bearer ${localStorage.getItem('token')}`
        }
    };
    httpClient.put('', employee, config);
});

export const signUpEmployeeSlice = createSlice({
    name: 'signUpEmployee',
    initialState: {
    },
    reducers: {
    },
    extraReducers(builder) {

    }
});


export default signUpEmployeeSlice.reducer;