import { configureStore, current } from '@reduxjs/toolkit';
import { jwtDecode, InvalidTokenError } from "jwt-decode";
import { CurrentAccount, WorkerType } from "../features/account/accountSlice";
import accountReducer from "../features/account/accountSlice";
import authenticationReducer from "../features/authentication/signup/signUpSlice";
import dashboardReducer from "../features/Employer/dashboard/dashboardSlice";
import employeesReducer from "../features/Employer/employee/employeesSlice";
import { useDispatch } from "react-redux";
import companiesReducer from "../features/Employer/companies/CompaniesSlice";
import subscriptionReducers from '../features/Employer/subscription/SubscriptionSlice';
import tasksReducer from '../features/Employer/tasks/tasksPageSlice';
import leyoutReducer from '../features/layout/layoutSlice';

const token = localStorage.getItem('token');

interface JwtData {
    exp: number,
    iat: number,
    name: string,
    token: string,
    type: WorkerType,
    company?: string
}

let jwtDecoded: JwtData = {} as JwtData;
let account: CurrentAccount = {
    name: '',
    isAuthenticated: false
};

if (token != null) {
    try {
        jwtDecoded = jwtDecode<JwtData>(token);
        account = {
            name: jwtDecode.name,
                isAuthenticated: jwtDecoded.exp * 1000 > Date.now() ? true : false,
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
        employerEmployees: employeesReducer,
        companies: companiesReducer,
        subscription: subscriptionReducers,
        tasks: tasksReducer,
        layout: leyoutReducer

    },
    preloadedState: {
        account: account
    }
});

export type AppDispatch = typeof store.dispatch;
export const useAppDispatch = useDispatch.withTypes<AppDispatch>();
export type IRootState = ReturnType<typeof store.getState>

export default store;
