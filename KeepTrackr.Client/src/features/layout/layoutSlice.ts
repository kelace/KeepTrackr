import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import MailIcon from '@mui/icons-material/Mail';

export interface MenuItem {
    icon: string,
    text: string,
    link: string
};

export interface LayoutInterface {
    employerMenu: MenuItem[],
    employeeMenu: MenuItem[]
};

const initialState: LayoutInterface = {

    employerMenu: [
        { text: 'Dashboard', link: 'dashboard', icon: 'dashboard' },
        { text: 'Tasks', link: 'tasks/companies', icon: 'task' },
        { text: 'Employees', link: 'employees', icon: 'badge'  },
        { text: 'Settings', link: 'configuration', icon: 'settings' },
        { text: 'Subscription', link: 'subscription', icon: 'payments' },
        { text: 'Companies', link: 'companies', icon: 'work' }
    ],

    employeeMenu: [
        { text: 'Home', link: 'employee/companies', icon: 'home' },
        { text: 'Settings', link: 'employee/configuration', icon: 'settings' },
    ]
}

const slice = createSlice({
    name: 'layout',
    initialState,
    reducers: {}
});

export default slice.reducer;