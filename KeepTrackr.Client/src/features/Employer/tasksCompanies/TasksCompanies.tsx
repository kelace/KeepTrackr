import React, { useEffect, useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import Box from '@mui/material/Box';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import Divider from '@mui/material/Divider';
import InboxIcon from '@mui/icons-material/Inbox';
import DraftsIcon from '@mui/icons-material/Drafts';
import { getAllCompanies } from '../companies/CompaniesSlice';
import { AppDispatch } from '../../../app/store';
import Link from '@mui/material/Link';
import { Link as RouterLink } from 'react-router-dom';

function TasksCompanies() {

    const companies = useSelector((x: any) => x.companies.companies);
    const dispatch = useDispatch<AppDispatch>();


    useEffect(() => {
        (async () => {
            await dispatch(getAllCompanies());
        })();
    }, []);

    return (
        <Box sx={{ width: '100%', maxWidth: 360, bgcolor: 'background.paper' }}>
            <nav aria-label="secondary mailbox folders">
                <List>

                    {companies.map((company: any) =>

                        <Link to={`/tasks/${company.name}`} component={RouterLink} key={company.id}>

                            <ListItem disablePadding>
                                {company.name}
                            </ListItem>

                        </Link>

                    )}

                </List>
            </nav>
        </Box>
    );
}

export default TasksCompanies;