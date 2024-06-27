import { configureStore, current } from '@reduxjs/toolkit';
import { jwtDecode, InvalidTokenError } from "jwt-decode";
import { CurrentAccount, WorkerType } from "../features/account/accountSlice";
import accountReducer from "../features/account/accountSlice";
import authenticationReducer from "../features/authentication/signup/signUpSlice";
import dashboardReducer from "../features/Employer/dashboard/dashboardSlice";
import employeesReducer from "../features/Employer/employee/employeesSlice";
import { useDispatch  } from "react-redux";

const token = localStorage.getItem('token');

interface JwtData {
    exp: number,
    name: string,
    token: string,
    type: WorkerType,
    company?: string
}

let jwtDecoded: JwtData = {} as JwtData;
let account: CurrentAccount = {} as CurrentAccount;

if (token != null) {
    try {
        jwtDecoded = jwtDecode<JwtData>(token);
        let noew = Date.now();
        account = {
            name: jwtDecode.name,
            isAuthenticated: jwtDecoded.exp > noew ? true : false,
            workerType: jwtDecoded.type,
        /*    company: jwtDecoded.company*/
        };
    } catch (e) {
    }
}

const store = configureStore({
    reducer: {
        account: accountReducer,
        authentication: authenticationReducer,
        dashboard: dashboardReducer,
        employerEmployees: employeesReducer
    },
    preloadedState: {
        account: account
    }
});

export type AppDispatch = typeof store.dispatch;
export const useAppDispatch = useDispatch.withTypes<AppDispatch>();

export default store;
