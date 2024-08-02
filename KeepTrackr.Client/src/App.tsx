import React from 'react';
import logo from './logo.svg';
import './App.css';
import AuthenticationPage from './features/account/AuthenticationPage';
import HomePage from './features/Employer/home/HomePage';
import { Outlet, redirect, useNavigate, useLocation, Navigate } from 'react-router-dom';
import { useSelector, useDispatch } from 'react-redux';
import { AppDispatch } from './app/store';
import { clear } from './features/Employer/subscription/SubscriptionSlice';

function App() {
    const isAuthenticated = useSelector((state: any) => {
        return state.account.isAuthenticated;
    });

    const dispatch = useDispatch<AppDispatch>();
    const location = useLocation();
    const navigate = useNavigate();

   React.useEffect(() => {
       if (!isAuthenticated) {
           navigate("/authentication/signin");
       }

       dispatch(clear());

   }, [location]);

  return (
      <div className="App">
          {isAuthenticated ? <Outlet />  : <Navigate to="/authentication/signin" />}
    </div>
  );
}

export default App;
