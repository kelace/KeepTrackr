import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { createBrowserRouter, RouterProvider, Navigate } from 'react-router-dom';
import AuthenticationPage from './features/account/AuthenticationPage';
import { Provider } from 'react-redux';
import store from './app/store'
import SignInPage from './features/authentication/signin/SignInPage';
import SignUpPage from './features/authentication/signup/SignUpPage';
import HomePage from './features/Employer/home/HomePage';
import TasksPage from './features/Employer/tasks/TasksPage';
import TasksCompanies from './features/Employer/tasksCompanies/TasksCompanies';
import DashboardPage from './features/Employer/dashboard/DashboardPage';
import EmployeesHomePage from './features/Employee/employeesHome/EmployeesHomePage';
import DashboardEmployeesPage from './features/Employee/dashboardEmployees/DashboardEmployeesPage';
import EmployeeTab from './features/Employer/employee/EmployeeTabt';
import SignUpEmployee from './features/authentication/signUpEmployee/SignUpEmployee';
import CompaniesComponent from './features/Employer/companies/CompaniesComponent';

const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children: [
            {
                path: "/",
                element: <HomePage />,
                children: [
                    {
                        path:'/dashboard',
                        element: <DashboardPage />,
                    },
                    {
                        path: '/tasks/:company',
                        element: <TasksPage />,
                    },
                    {
                        path: '/tasks/companies',
                        element: <TasksCompanies />,
                    },
                    {
                        path: '/configuration',
                        element: <DashboardPage />,
                    },
                    {
                        path: '/employees',
                        element: <EmployeeTab />,
                    },
                    {
                        path: '/subscription',
                        element: <DashboardPage />,
                    },
                    {
                        path: '/companies',
                        element: <CompaniesComponent />,
                    }
                ]
            },
            {
            path: "/company/:company/",
            element: <EmployeesHomePage />,
            children:[
                {
                    path: "/company/:company/dashboard",
                    index: true,
                    element: <DashboardEmployeesPage/>
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
    <React.StrictMode>
        <Provider store={store}>
            <RouterProvider router={router} />
        </Provider>
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
