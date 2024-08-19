import React, { useEffect, FormEvent, useState, ChangeEvent } from 'react';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import { AppDispatch, IRootState } from '../../../app/store';
import { useSelector, useDispatch } from 'react-redux';
import { getAllCompanies, CompaniesState, Company, addCompany } from './CompaniesSlice';
import { nameChange } from './CompaniesSlice';

function CompaniesComponent() {

    const dispatch = useDispatch<AppDispatch>();
    const companies = useSelector((x: IRootState) => x.companies.companies);
    const errors = useSelector((x: IRootState) => x.companies.errors);

    const company = useSelector((state: IRootState) => state.companies.name);

    useEffect(() => {
        const count = companies.length;


        (async () => {
            if(count == 0) await dispatch(getAllCompanies());
        })();
        
    }, []);

    const onChangeInputHandler = (e: ChangeEvent<HTMLInputElement>) => {
        dispatch(nameChange(e.target.value));
    }

    const submitFormHandler = async (e: FormEvent) => {
        e.preventDefault();
        await dispatch((addCompany(company)));
    };

  return (
      <div>
          <form onSubmit={submitFormHandler}>
              <TextField onChange={ onChangeInputHandler } value={company.name} id="standard-basic" label="Standard" variant="standard" />
              <Button type="submit" variant="text">Text</Button>
          </form>

          {errors.map((error: any) => (
          
              <div key={error.description }>
                  {error.description }
              </div>

          ))}

          <TableContainer component={Paper}>
              <Table sx={{ minWidth: 650 }} aria-label="simple table">
                  <TableHead>
                      <TableRow>
                      <TableCell>Name</TableCell>


                      </TableRow>
                  </TableHead>
                  <TableBody>
                      {companies.map((row: Company) => (
                          <TableRow
                              key={row.name}
                              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                          >
                              <TableCell component="th" scope="row">
                                  {row.name}
                              </TableCell>
                          </TableRow>
                      ))}
                  </TableBody>
              </Table>
          </TableContainer>
      </div>
  );
}

export default CompaniesComponent;