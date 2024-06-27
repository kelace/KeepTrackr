import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import axios from 'axios';

export const inviteEmployee = createAsyncThunk('employee/invite', async (employee: {name : string, email: string}) => {

    const token = localStorage.getItem('token');

    const config = {
        headers: {
            Authorization: `Bearer ${token}`
        }
    };
    const result = await axios.post('http://localhost:5222/api/employee/invitation', employee, config);

/*    alert(result.data.email);*/

    return result.data;
});

const employeesSlice = createSlice({
    name: 'employerEmployees',
    initialState: {
        employees: [],
        modal: false,
        modalText: ''
    },
    reducers: {},
    extraReducers(builder) {
        builder.addCase(inviteEmployee.fulfilled, (state: any, action: any) => {
            const employee = action.payload.employee;

            state.employees.push(employee);
            state.modalText = action.payload.email;
        })
    }
});

export default employeesSlice.reducer;