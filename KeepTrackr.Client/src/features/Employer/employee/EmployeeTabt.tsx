import React, { useState, ChangeEvent, MouseEvent } from 'react';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import { useDispatch, useSelector } from 'react-redux';
import { inviteEmployee } from './employeesSlice';
import { AppDispatch } from '../../../app/store';
import Modal from '@mui/material/Modal';
import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';

function EmployeeTab() {
    const dispatch = useDispatch<AppDispatch>();

    const [inviteData, setInviteData] = useState({
        email: '',
        name: ''
    });

    const [open, setOpen] = useState(false);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);

    const modalText = useSelector((state: any) => state.employerEmployees.modalText);

    const handleEmailChange = (e: ChangeEvent<HTMLInputElement>) => {
        setInviteData({
            ...inviteData,
            email: e.target.value
        })
    };

    const handleNameChange = (e: ChangeEvent<HTMLInputElement>) => {
        setInviteData({
            ...inviteData,
            name: e.target.value
        })
    };

    const handleSubmit = (e: MouseEvent<HTMLButtonElement>) => {
        e.preventDefault();
        dispatch(inviteEmployee(inviteData));
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
                        { modalText }
                    </Typography>
                </Box>
            </Modal>
            <form >
            
                    <TextField id="employee-email"
                        label="Employee email"
                    fullWidth
                    margin="dense"
                    onChange={handleEmailChange }
                        name="employee-email" variant="outlined" />
       
                    <TextField id="employee-name"
                        label="Employee name"
                    fullWidth
                    margin="dense"
                    onChange={handleNameChange}
                        name="employee-name" variant="outlined" />

                <Button onClick={handleSubmit} variant="contained">Invite</Button>

            </form>
      </div>
  );
}

export default EmployeeTab;