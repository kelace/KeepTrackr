import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import httpClient from '../../../app/httpClient';

export const signUpSlice = createSlice({
    name: 'authentication',
    initialState: {
        status: true,
        errors: []
    },
    reducers: {
    }
});

export default signUpSlice.reducer;