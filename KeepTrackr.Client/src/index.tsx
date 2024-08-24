import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { createBrowserRouter, RouterProvider, Navigate, Outlet } from 'react-router-dom';
import AuthenticationPage from './features/account/AuthenticationPage';
import { Provider } from 'react-redux';
import store from './app/store'
import SignInPage from './features/authentication/signin/SignInPage';
import SignUpPage from './features/authentication/signup/SignUpPage';
import HomePage from './features/Employer/home/HomePage';
import TasksPage from './features/Employer/tasks/TasksPage';
import TasksCompanies from './features/Employer/tasksCompanies/TasksCompanies';
import DashboardPage from './features/Employer/dashboard/DashboardPage';
//import EmployeesHomePage from './features/Employee/employeesHome/EmployeesHomePage';
//import DashboardEmployeesPage from './features/Employee/dashboardEmployees/DashboardEmployeesPage';
import EmployeeTab from './features/Employer/employee/EmployeeTabt';
import SignUpEmployee from './features/authentication/signUpEmployee/SignUpEmployee';
import CompaniesComponent from './features/Employer/companies/CompaniesComponent';
import SubscriptionPage from './features/Employer/subscription/SubscriptionPage';
import WorkerTypeProtector from './app/WorkerTypeProtector';
import Layout from './features/layout/Layout';
import { WorkerType } from './features/account/accountSlice';

const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children: [
            {
                index: true,
                element: <Navigate to="/dashboard"/>
            },
            {
                path: '/dashboard',
                element: <WorkerTypeProtector type={WorkerType.Employer}><DashboardPage /></WorkerTypeProtector>,
            },
            {
                path: '/tasks/:company',
                element: <WorkerTypeProtector type={WorkerType.Employer}><TasksPage /></WorkerTypeProtector>,
            },
            {
                index: true,
                path: '/tasks/companies',
                element: <WorkerTypeProtector type={WorkerType.Employer}><TasksCompanies /></WorkerTypeProtector>,
            },
            {
                path: '/configuration',
                element: <WorkerTypeProtector type={WorkerType.Employer}><DashboardPage /></WorkerTypeProtector>,
            },
            {
                path: '/employees',
                element: <WorkerTypeProtector type={WorkerType.Employer}><EmployeeTab /></WorkerTypeProtector>,
            },
            {
                path: '/subscription',
                element: <WorkerTypeProtector type={WorkerType.Employer}><SubscriptionPage /></WorkerTypeProtector>,
            },
            {
                path: '/companies',
                element: <WorkerTypeProtector type={WorkerType.Employer}><CompaniesComponent /></WorkerTypeProtector>,
            },
            {
                path: "/employee",
                element: <WorkerTypeProtector type={WorkerType.Employee}><Outlet /></WorkerTypeProtector>,
                children: [
                    {
                        path: "companies",
                        element: <TasksCompanies/> 
                    },
                    {
                        path: "tasks/:company",
                        element: <TasksPage />
                    },
                    {
                        path: "settings",
                        index: true,
                        element: <div>employee settings</div> 
                    }
                ]
            }
        ]
    },
    {
        path: "/authentication",
        element: <AuthenticationPage />,
        children: [
            {
                index: true,
                element: <Navigate to="signin" />
            },
            {
                path: "/authentication/signin",
                element: <SignInPage />
            },
            {
                path: "/authentication/signup",
                element: <SignUpPage />
            },
            {
                path: "/authentication/invitation/signup",
                element: <SignUpEmployee />
            },
        ]
    },
]);

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

root.render(
/*    <React.StrictMode>*/
        <Provider store={store}>
            <RouterProvider router={router} />
        </Provider>
/*  </React.StrictMode>*/
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
