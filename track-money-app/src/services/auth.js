import * as axios from 'axios';
import { userAuthenticated } from '../app/auth/authSlice';


const axiosInstance = axios.default.create({
    baseURL:`https://localhost:7188/Users`,
});
export const SignUp = async (dispatch, credentials)=>{
    try{
        const {data} = await axiosInstance.post('https://localhost:7188/Users/sign-up',credentials);
        dispatch(userAuthenticated(data));
    }
    catch{
        console.log('Error');
    }
}


export const SignIn = async (dispatch, credentials)=>{
    try{
        const {data} = await axiosInstance.post('https://localhost:7188/Users/sign-in',credentials);
        dispatch(userAuthenticated(data));
    }
    catch{
        console.log('Error');
    }
}