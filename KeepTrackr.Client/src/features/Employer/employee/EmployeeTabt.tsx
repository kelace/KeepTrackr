import React, { useState, ChangeEvent, MouseEvent, useEffect } from 'react';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import { useDispatch, useSelector } from 'react-redux';
import { inviteEmployee, updateNewEmployee, fetchEmployees } from './employeesSlice';
import { AppDispatch, IRootState } from '../../../app/store';
import Modal from '@mui/material/Modal';
import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import Select, { SelectChangeEvent } from '@mui/material/Select';
import MenuItem from '@mui/material/MenuItem';

function EmployeeTab() {

    const dispatch = useDispatch<AppDispatch>();

    useEffect(() => {

        dispatch(fetchEmployees());

    }, []);

    const [open, setOpen] = useState(false);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);


    const employees = useSelector((x: any) => x.employerEmployees.employees);

    const newEmployee = useSelector((x: any) => x.employerEmployees.newEmployee);

    const modalText = useSelector((state: any) => state.employerEmployees.modalText);

    const companies = useSelector((x: IRootState) => x.companies.companies);

    const handleEmailChange = (e: ChangeEvent<HTMLInputElement>) => {

        dispatch(updateNewEmployee({
            ...newEmployee,
            email: e.target.value
        }));
        //setInviteData({
        //    ...inviteData,
        //    email: e.target.value
        //})
    };

    const handleNameChange = (e: ChangeEvent<HTMLInputElement>) => {

        dispatch(updateNewEmployee({
            ...newEmployee,
            name: e.target.value
        }));
        //setInviteData({
        //    ...inviteData,
        //    name: e.target.value
        //})
    };

    const handleCompanyChange = (e: SelectChangeEvent<string[]>) => {
        dispatch(updateNewEmployee({
            ...newEmployee,
            companies: e.target.value
        }));
    }

    const handleSubmit = (e: MouseEvent<HTMLButtonElement>) => {
        e.preventDefault();
        dispatch(inviteEmployee(newEmployee));
        handleOpen();
    };

    const style = {
        wordBreak: 'break-word',
        position: 'absolute' as 'absolute',
        top: '50%',
        left: '50%',
        transform: 'translate(-50%, -50%)',
        width: 400,
        bgcolor: 'background.paper',
        border: '2px solid #000',
        boxShadow: 24,
        p: 4
    };

    return (
        <div>
            <Modal
                open={open}
                onClose={handleClose}
                aria-labelledby="modal-modal-title"
                aria-describedby="modal-modal-description"
            >
                <Box sx={style}>
                    <Typography id="modal-modal-title" variant="h6" component="h2">
                        Text in a modal
                    </Typography>
                    <Typography id="modal-modal-description" sx={{ mt: 2 }}>
                        {modalText}
                    </Typography>
                </Box>
            </Modal>
            <form >

                <TextField id="employee-email"
                    label="Employee email"
                    fullWidth
                    margin="dense"
                    value={newEmployee.email}
                    onChange={handleEmailChange}
                    name="employee-email" variant="outlined" />

                <TextField id="employee-name"
                    label="Employee name"
                    fullWidth
                    margin="dense"
                    value={newEmployee.name}
                    onChange={handleNameChange}
                    name="employee-name" variant="outlined" />

                <Select
                    labelId="demo-multiple-name-label"
                    id="demo-multiple-name"
                    onChange={handleCompanyChange}
                    multiple
                    value={newEmployee.companies}

                >
                    {companies.map((company: any) => (
                        <MenuItem
                            key={company.name}
                            value={company.name}
                        >
                            {company.name}
                        </MenuItem>
                    ))}
                </Select>

                <Button onClick={handleSubmit} variant="contained">Invite</Button>

            </form>

            {employees.map((x: any) => <div key={x.id}>{x.name}</div>)}

        </div>
    );
}

export default EmployeeTab;