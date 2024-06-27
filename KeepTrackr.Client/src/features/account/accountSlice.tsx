import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import httpClient from '../../app/httpClient';

export const signInUser = createAsyncThunk("authentication/signin", async(user : any) => {
    const result = await httpClient.post("/api/authorization/signin", { Name: user.name, Password: user.password, RememberMe: user.rememberMe });
    localStorage.setItem("token", result.data.token);
    return result.data;
});

export const signUpUser = createAsyncThunk("authentication/signup", async (user: any) => {
    const result = await httpClient.post("/api/authorization/signup", { Name: user.name, Password: user.password, ConfirmPassword: user.confirmPassword});
    localStorage.setItem("token", result.data.token);
    return result.data;
});

export const accountSlice = createSlice({
    name: 'account',
    initialState: { },
    reducers: {

    },
    extraReducers(builder) {
        builder.addCase(signInUser.fulfilled, (state: any, action) => {
            state.isAuthenticated = action.payload.succeeded ?  true : false;
            state.workerType = action.payload.workerType;
            state.name = action.payload.name;
        });

        builder.addCase(signUpUser.fulfilled, (state: any, action) => {

            if (action.payload.succeeded) {
                state.isAuthenticated = action.payload.succeeded;
                state.workerType = action.payload.workerType;
                state.name = action.payload.name;
                return;
            }

            state.status = false;
            state.errors = action.payload.errors;
        })
    }
});

export interface CurrentAccount {
    name: string,
    isAuthenticated: boolean,
    workerType: WorkerType,
    company?: string
}

export enum WorkerType {
    Employee,
    Employer
}

export default accountSlice.reducer;