import React from 'react';
import logo from './logo.svg';
import './App.css';
import AuthenticationPage from './features/account/AuthenticationPage';
import HomePage from './features/Employer/home/HomePage';
import { Outlet, redirect, useNavigate, useLocation, Navigate } from 'react-router-dom';
import { useSelector, useDispatch } from 'react-redux';
import { AppDispatch } from './app/store';
import { clear } from './features/Employer/subscription/SubscriptionSlice';
import Layout from './features/layout/Layout';



function App() {
    const isAuthenticated = useSelector((state: any) => {
        return state.account.isAuthenticated;
    });

    const dispatch = useDispatch<AppDispatch>();
    const location = useLocation();
    const navigate = useNavigate();

   React.useEffect(() => {
/*       navigate("/authentication/signin");*/

/*       dispatch(clear());*/

    }, [location]);

   if (!isAuthenticated) return <Navigate to="/authentication/signin" />;

  return (
      <div className="App">
          <Layout><Outlet /> </Layout>
    </div>
  );
}

export default App;
