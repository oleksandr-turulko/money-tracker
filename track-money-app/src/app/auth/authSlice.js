import { createSlice } from '@reduxjs/toolkit';

export const authSlice = createSlice({
    name: 'authentication',
    initialState: {
        token: '',
        isLoggedIn: false
    },
    reducers: {
        userAuthenticated: (state, action) => {
            sessionStorage.setItem('token', action.payload.token);
            return {
                ...state, ...{
                    token: action.payload.token,
                    isLoggedIn: true
                }
            }
        },
        logout: () => {
            sessionStorage.clear();
        }
    }
});

export const {userAuthenticated,logout} = authSlice.actions;

export default authSlice.reducer;