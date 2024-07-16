import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import httpClient from '../../../app/httpClient';

export const addCompany = createAsyncThunk('companies/addNewCompany', async (company: string) => {
    const token = localStorage.getItem('token');

    const config = {
        headers: {
            Authorization: `Bearer ${token}`
        }
    };

    const result = await httpClient.post('api/company', { name: company } , config);

    return { ...result.data, name: company };
});


export const getAllCompanies = createAsyncThunk('companies/fetchCompanies', async () => {
    const token = localStorage.getItem('token');

    const config = {
        headers: {
            Authorization: `Bearer ${token}`
        }
    };

    const result = await httpClient.get('api/company', config);

    return result.data;

});

export interface CompaniesState {
    companies: Company[],
    companiesLoading: boolean,
    errors: { type: string, description: string }[],
    name: string
}

export interface Company {
    name: string;
}

const initialState: CompaniesState = {
    companies: [],
    companiesLoading: false,
    errors: [],
    name:''
};

const slice = createSlice({
    name: 'companies',
    initialState: initialState,
    reducers: {
        nameChange: (state: CompaniesState, action) => {
            if (state.errors.length != 0) state.errors = [];
            state.name = action.payload
        }
    },
    extraReducers(builder) {

        builder.addCase(addCompany.fulfilled, (state: CompaniesState, action: any) => {

            if (action.payload.status) {
                state.companies.push({ name: action.payload.name });
                return;
            }

            state.errors.push(action.payload.error);

        });

        builder.addCase(getAllCompanies.pending, (state: any, action: any) => {
            state.companiesLoading = true;
        });

        builder.addCase(getAllCompanies.fulfilled, (state: CompaniesState, action: any) => {
            state.companies = action.payload;

            state.companiesLoading = false;
        });
    }
});

export const { nameChange } = slice.actions;

export default slice.reducer;