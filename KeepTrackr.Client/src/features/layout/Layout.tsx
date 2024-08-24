import React, { useEffect } from 'react';
import { useDispatch } from 'react-redux';
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
import { WorkerType, logOut } from '../account/accountSlice';
import Link from '@mui/material/Link';
import { Link as RouterLink } from 'react-router-dom';
import Icon from '@mui/material/Icon';
import { IRootState, AppDispatch } from '../../app/store';
import './Layout.css';

const drawerWidth = 240;

function Layout(props: any) {

    const workerType: WorkerType = useSelector((x: any) => x.account.workerType);

    const menus = useSelector((x: IRootState) => workerType == WorkerType.Employer ? x.layout.employerMenu : x.layout.employeeMenu);


    const dispatch = useDispatch<AppDispatch>();

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
                    { menus.map((item: any, index: any ) => (
                        <Link to={item.link} component={RouterLink} key={item.text}>
                            <ListItem key={item.text} disablePadding>
                                <ListItemButton>
                                    <ListItemIcon>
                           
                                        <Icon>
                                 
                                            {item.icon}

                                        </Icon>
                                    </ListItemIcon>
                                    <ListItemText primary={item.text} />
                                </ListItemButton>
                            </ListItem>
                        </Link>
                       
                    ))}
                    <Divider />
                    <ListItem disablePadding>
                        <ListItemButton>
                            <ListItemIcon>

                                <Icon>

                                    'logout'
                                </Icon>
                            </ListItemIcon>
                            <ListItemText primary="logout" onClick={() => dispatch(logOut()) } />
                        </ListItemButton>
                    </ListItem>
                </List>
            </Drawer>
            <Box
                component="main"
                sx={{ flexGrow: 1, bgcolor: 'background.default', p: 3 }}
            >
                <Toolbar />
                { props.children }
            </Box>
        </Box>
    );
}

export default Layout;