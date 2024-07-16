import * as React from 'react';
import { useEffect } from 'react';
import Box from '@mui/material/Box';
import Drawer from '@mui/material/Drawer';
import CssBaseline from '@mui/material/CssBaseline';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import List from '@mui/material/List';
import Typography from '@mui/material/Typography';
import Divider from '@mui/material/Divider';
import ListItem from '@mui/material/ListItem';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import InboxIcon from '@mui/icons-material/MoveToInbox';
import MailIcon from '@mui/icons-material/Mail';
import { useSelector } from 'react-redux';
import { Outlet, useNavigate } from 'react-router-dom';
import { WorkerType } from '../../account/accountSlice';
import Link from '@mui/material/Link';
import { Link as RouterLink } from 'react-router-dom';

const drawerWidth = 240;

function HomePage() {

    const workerType : WorkerType = useSelector((state: any) => state.account.workertype );
    const company : WorkerType = useSelector((state: any) => state.account.company );
    const navigate = useNavigate();

    useEffect(() => {

        if (workerType == WorkerType.Employee) {
            navigate(`/company/${company}`);
        } else {
            navigate("/dashboard/");
        }
    }, [])

    return (
        <Box sx={{ display: 'flex' }}>
            <CssBaseline />
            <AppBar
                position="fixed"
                sx={{ width: `calc(100% - ${drawerWidth}px)`, ml: `${drawerWidth}px` }}
            >
                <Toolbar>
                    <Typography variant="h6" noWrap component="div">
                        Permanent drawer
                    </Typography>
                </Toolbar>
            </AppBar>
            <Drawer
                sx={{
                    width: drawerWidth,
                    flexShrink: 0,
                    '& .MuiDrawer-paper': {
                        width: drawerWidth,
                        boxSizing: 'border-box',
                    },
                }}
                variant="permanent"
                anchor="left"
            >
                <Toolbar />
                <Divider />
                <List>
                    {[{ text: 'Dashboard', link: 'dashboard' }, { text: 'Tasks', link: 'tasks' }, { text: 'Employees', link: 'employees' }, { text: 'Settings', link: 'configuration' }, { text: 'Subscription', link: 'subscription' }, { text: 'Companies', link: 'companies' }].map((item: any, index) => (
                        <Link to={item.link} component={RouterLink} key={item.text}>
                            <ListItem key={item.text} disablePadding>
                                <ListItemButton>
                                    <ListItemIcon>
                                        {index % 2 === 0 ? <InboxIcon /> : <MailIcon />}
                                    </ListItemIcon>
                                    <ListItemText primary={item.text} />
                                </ListItemButton>
                            </ListItem>
                        </Link>
    
                    ))}
                </List>
            </Drawer>
            <Box
                component="main"
                sx={{ flexGrow: 1, bgcolor: 'background.default', p: 3 }}
            >
                <Toolbar />
                <Outlet/>
            </Box>
        </Box>
    );
}

export default HomePage;