import {ExpenseActionTypes} from './ExpenseActionTypes';
import {ExpenseActionCreators} from './ExpenseActions';

const initialState = {
    expenses: [],
};




export default (state = initialState, action) => {
    switch (action.type) {
        case ExpenseActionTypes.SET_EXPENSES:
            return { ...state, expenses: [...action.payload] };
        case ExpenseActionTypes.NEW_EXPENSE:
            return {...state, expenses:[action.payload,...state.expenses]}
        case ExpenseActionTypes.EDIT_EXPENSE:
            var expenses = state.expenses.map(e=>{
                if(e.id===action.payload.id){
                    e = action.payload;
                }
                return e;
            })
            return { ...state, expenses: [...expenses] };
        case ExpenseActionTypes.DELETE_EXPENSE:
            var expenses = state.expenses.filter(e=>
                e.id !== action.payload.id);
            return {...state, expenses:[...expenses]}
        default:
            return state;
    }
}