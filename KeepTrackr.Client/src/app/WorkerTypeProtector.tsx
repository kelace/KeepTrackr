import React from 'react';
import { useSelector } from 'react-redux';
import { WorkerType } from '../features/account/accountSlice';
import { Navigate } from 'react-router-dom';

function WorkerTypeProtector(props: any) {

    const componentType = props.type;
    const workerType = useSelector((state: any) => state.account.workerType);

    if (componentType == WorkerType.Employer && workerType != WorkerType.Employer) return <Navigate to="/employee" />
    if (componentType == WorkerType.Employee && workerType != WorkerType.Employee) return <Navigate to="/dashboard" />

    return (
        <div>
            {props.children}
        </div>
  );
}

export default WorkerTypeProtector;