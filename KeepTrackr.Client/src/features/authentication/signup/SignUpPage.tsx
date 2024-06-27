import React from 'react';
import { useState, FormEvent } from 'react';
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import CssBaseline from '@mui/material/CssBaseline';
import TextField from '@mui/material/TextField';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import Link from '@mui/material/Link';
import Grid from '@mui/material/Grid';
import Box from '@mui/material/Box';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import { createTheme, ThemeProvider } from '@mui/material/styles';
import { signUpUser } from '../../account/accountSlice';
import { useDispatch, useSelector } from 'react-redux';
import { AppDispatch } from '../../../app/store';
import { Link as RouterLinkl, useNavigate } from 'react-router-dom';

const defaultTheme = createTheme();

function SignUpPage() {
    const [signUpForm, setSignUpForm] = useState({
        name: "",
        password: "",
        confirmPassword: "",
        rememberMe: true,
    });

    const status = useSelector((state : any) => state.authentication.status );
    const errors = useSelector((state: any) => state.authentication.errors);
    const navigate = useNavigate();

    const dispatch = useDispatch<AppDispatch>();

    const handleSubmit = async (e: FormEvent) => {
        e.preventDefault();
        await dispatch(signUpUser(signUpForm));
        navigate("/");
    };

    return (
        <ThemeProvider theme={defaultTheme}>
            <Container component="main" maxWidth="xs">
                <CssBaseline />
                <Box
                    sx={{
                        marginTop: 8,
                        display: 'flex',
                        flexDirection: 'column',
                        alignItems: 'center',
                    }}
                >
                    <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
                        <LockOutlinedIcon />
                    </Avatar>
                    <Typography component="h1" variant="h5">
                        Sign in
                    </Typography>
                    <Box component="form" onSubmit={handleSubmit} noValidate sx={{ mt: 1 }}>
                        <TextField
                            margin="normal"
                            required
                            fullWidth
                            id="email"
                            label="Name"
                            name="email"
                            autoComplete="email"
                            autoFocus
                            value={signUpForm.name}
                            onChange={(e: any) => {
                                setSignUpForm({
                                    ...signUpForm,
                                    name: e.target.value
                                });
                            }}
                        />
                        <TextField
                            margin="normal"
                            required
                            fullWidth
                            name="password"
                            label="Password"
                            type="password"
                            id="password"
                            autoComplete="current-password"
                            value={signUpForm.password}
                            onChange={(e: any) => {
                                setSignUpForm({
                                    ...signUpForm,
                                    password: e.target.value
                                });
                            }}
                        />
                        <TextField
                            margin="normal"
                            required
                            fullWidth
                            name="confirmPassword"
                            label="Confirm Password"
                            type="password"
                            id="confirmPassword"
                            autoComplete="current-password"
                            value={signUpForm.confirmPassword}
                            onChange={(e: any) => {
                                setSignUpForm({
                                    ...signUpForm,
                                    confirmPassword: e.target.value
                                });
                            }}
                        />
                        <FormControlLabel
                            control={<Checkbox value="remember" color="primary" />}
                            label="Remember me"
                            value={signUpForm.rememberMe}
                            onChange={(e: any) => {
                                setSignUpForm({
                                    ...signUpForm,
                                    rememberMe: e.target.value
                                });
                            }}
                        />
                        <Button
                            type="submit"
                            fullWidth
                            variant="contained"
                            sx={{ mt: 3, mb: 2 }}
                        >
                            Sign Up
                        </Button>

                        {status ? '' : errors.map((error: any) => <li> error.Description</li>) }

                        <Grid container>
                            <Grid item xs>
                                <Link href="#" variant="body2">
                                    Forgot password?
                                </Link>
                            </Grid>
                            <Grid item>
                                <Link component={RouterLinkl} to="/authentication/signin" variant="body2">
                                    {"Have an account? Sign Up"}
                                </Link>
                            </Grid>
                        </Grid>
                    </Box>
                </Box>
            </Container>
        </ThemeProvider>
    );
}

export default SignUpPage;