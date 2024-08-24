import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import httpClient from '../../../app/httpClient';
import axios from 'axios';

export const inviteEmployee = createAsyncThunk('employee/invite', async (employee: {name : string, email: string, companies: string[]}) => {

    const token = localStorage.getItem('token');

    const config = {
        headers: {
            Authorization: `Bearer ${token}`
        }
    };

    const result = await httpClient.post('http://localhost:5222/api/employee/invitation', employee, config);

/*    alert(result.data.email);*/

    return result.data;
});

export const fetchEmployees = createAsyncThunk('employee/fetchEmployees', async () => {
    const token = localStorage.getItem('token');

    const config = {
        headers: {
            Authorization: `Bearer ${token}`
        }
    };

    const result = await httpClient.get('api/employee/', config);

    return result.data;
});

export interface Employee {
    name: string,
    email: string,
    companies: string[]
}

export interface EmployeeState {
    employees: Employee[],
    newEmployee: Employee,
    modal: boolean,
    modalText: string
};

const employeesSlice = createSlice({
    name: 'employerEmployees',
    initialState: {
        employees: [],
        newEmployee: {
            name: '',
            email: '',
            companies: [],
        },
        modal: false,
        modalText: ''
    },
    reducers: {
        updateNewEmployee: (state: any, action: any) => {
            state.newEmployee.name = action.payload.name;
            state.newEmployee.email = action.payload.email;
            state.newEmployee.companies = action.payload.companies;
        }
    },
    extraReducers(builder) {
        builder.addCase(inviteEmployee.fulfilled, (state: any, action: any) => {
            const employee = action.payload.employee;

            state.employees.push(employee);
            state.modalText = action.payload.email;
        });

        builder.addCase(fetchEmployees.fulfilled, (state: any, action: any) => {

            state.employees = action.payload;

        });
    }
});
export const { updateNewEmployee } = employeesSlice.actions;
export default employeesSlice.reducer;