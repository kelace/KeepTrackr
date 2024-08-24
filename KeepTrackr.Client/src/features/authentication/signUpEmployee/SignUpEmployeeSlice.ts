import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import httpClient from '../../../app/httpClient';


export const signUpEmployee = createAsyncThunk('signUpEmployee/signUp', async (employee: any) => {

    //const config = {
    //    headers: {
    //        Authorization: `Bearer ${localStorage.getItem('token')}`
    //    }
    //};
    httpClient.put('', employee);
});

export const signUpEmployeeSlice = createSlice({
    name: 'signUpEmployee',
    initialState: {
    },
    reducers: {
    },
    extraReducers(builder) {
        builder.addCase(signUpEmployee.fulfilled, (state: any, action: any) => {

        });
    }
});


export default signUpEmployeeSlice.reducer;