import {ExpenseActionTypes} from './ExpenseActionTypes';
export const ActionCreators = {
    setExpenses: payload => ({ type: ExpenseActionTypes.SET_EXPENSES, payload }),
    newExpense: payload => ({ type: ExpenseActionTypes.NEW_EXPENSE, payload }),
    editExpense: payload => ({ type: ExpenseActionTypes.EDIT_EXPENSE, payload }),
    deleteExpense: payload => ({ type: ExpenseActionTypes.DELETE_EXPENSE, payload }),
}
