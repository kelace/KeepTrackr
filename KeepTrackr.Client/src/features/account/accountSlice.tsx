import { Build } from '@mui/icons-material';
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

export const logOut = createAsyncThunk("authentication/logOut", () => {
    localStorage.setItem("token", '');
});

export const employeeSingUp = createAsyncThunk("authentication/employeeSignUp", async (employee: any) => {

    const result = await httpClient.put('/api/authorization/invitation/signup', employee);

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
        });

        builder.addCase(logOut.fulfilled, (state: any, action: any) => {

            state.isAuthenticated = false;
            state.workerType = null;
            state.name = null;

        });

        builder.addCase(employeeSingUp.fulfilled, (state: any, action: any) => {
            state.isAuthenticated = true;
            state.workerType = WorkerType.Employee;
            state.name = action.name;
        });
    }
});

export interface CurrentAccount {
    name: string,
    isAuthenticated: boolean,
    workerType?: WorkerType,
    company?: string
}

export enum WorkerType {
    Employee = 'Employee',
    Employer = 'Employer'
}

export default accountSlice.reducer;