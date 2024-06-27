import React from 'react';
import logo from './logo.svg';
import './App.css';
import AuthenticationPage from './features/account/AuthenticationPage';
import HomePage from './features/Employer/home/HomePage';
import { Outlet, redirect, useNavigate } from 'react-router-dom';
import { useSelector } from 'react-redux';

function App() {
    const isAuthenticated = useSelector((state: any) => {
        return state.account.isAuthenticated;
    });

    const navigate = useNavigate();

   React.useEffect(() => {
       if (!isAuthenticated) {
           navigate("/authentication/signin");
        }
   }, []);

  return (
      <div className="App">
          <Outlet />
    </div>
  );
}

export default App;
