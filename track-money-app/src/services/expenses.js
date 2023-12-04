import { ActionCreators } from "../app/expenses/ExpenseActions";
import * as axios from 'axios';

const axiosInstance = axios.default.create({
    baseURL: `https://localhost:7188/Transactions/`,
});

export const GetExpenses = async (dispatch) => {
    try {
        //api call
        var token = sessionStorage.getItem('token');
        const { data } = await axiosInstance.get('https://localhost:7188/Transactions/',
            { headers: { "Authorization": `Bearer ${token}` } });
        dispatch(ActionCreators.setExpenses(data))
    }
    catch {
        console.log("Error");
    }
}

export const NewExpense = async (dispatch, expense) => {
    try {
        // API call
        var token = sessionStorage.getItem('token');
        const response = await axiosInstance.post('https://localhost:7188/Transactions/',{requst:{
            Description:expense.description,
            Currency:expense.currency
        }},{
            headers: { "Authorization": `Bearer ${token}`,
                        'Content-Type' : 'text/json' },
            
        });

        // Assuming your API response is in response.data
        dispatch(ActionCreators.newExpense({
            id: response.data.id,
            description: response.data.description,
            amount: response.data.amount
        }));
    } catch (error) {
        console.error("Error:", error);
    }
}

export const EditExpense = async (dispatch, expense) => {
    try {
        //api call
        dispatch(ActionCreators.editExpense(expense));
    }
    catch {
        console.log("Error");
    }
}

export const DeleteExpense = async (dispatch, expense) => {
    try {
        //api call
        dispatch(ActionCreators.deleteExpense(expense));
    }
    catch {
        console.log("Error");
    }
}