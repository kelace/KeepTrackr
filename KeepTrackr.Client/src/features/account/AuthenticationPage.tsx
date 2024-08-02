import React from 'react';
import { Outlet, useNavigate, Navigate } from 'react-router-dom';
import { useSelector } from 'react-redux';

function AuthenticationPage() {
    const isAuthenticated = useSelector((state: any) => state.account.isAuthenticated);

    //const navigate = useNavigate();

    //if (isAuthenticated) {
    //    navigate("/");
    //}


    //React.useEffect(() => {
    //    if (isAuthenticated) {
    //        navigate("/");
    //    }
    //}, [isAuthenticated]);

    return (
        <div>
            {isAuthenticated ? <Navigate to="/"/> : <Outlet/> }
        </div> 
  );
}

export default AuthenticationPage;