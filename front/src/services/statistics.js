import * as axios from 'axios';
import { setTransactionAmountPerCategory } from '../app/statisticsSlice';

const axiosInstance = axios.create({
    baseURL: `${process.env.REACT_APP_BASE_URL}/statistics`,
});

axiosInstance.interceptors.request.use((config) => {
    config.headers = { authorization: 'Bearer ' + sessionStorage.getItem('token') };
    return config;
});

export const getTransactionsPerCategory = async (dispatch) => {
    try {
        const { data } = await axiosInstance.get();
        dispatch(setTransactionAmountPerCategory(data));
    } catch (error) {
        console.log(error);
    }
}