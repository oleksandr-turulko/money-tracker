import { createSlice, createAction } from '@reduxjs/toolkit';

export const setTransactionsError = createAction('setTransactionsError');
export const newTransactionError = createAction('newTransactionError');
export const editTransactionError = createAction('editTransactionError');
export const deleteTransactionError = createAction('deleteTransactionError');

export const TransactionsSlice = createSlice({
    name: 'Transactions',
    initialState: {
        Transactions: [],
    },
    reducers: {
        setTransactions: (state, action) => {
            return { ...state, Transactions: [...action.payload] };
        },
        newTransaction: (state, action) => {
            return { ...state, Transactions: [action.payload, ...state.Transactions] }
        },
        editTransaction: (state, action) => {
            const Transactions = state.Transactions.map(transaction => {
                if (transaction.id === action.payload.id) {
                    transaction = action.payload;
                }
                return transaction;
            });
            return { ...state, Transactions: [...Transactions] };
        },
        deleteTransaction: (state, action) => {
            const Transactions = state.Transactions.filter(transaction =>
                transaction.id !== action.payload.id);
            return { ...state, Transactions: [...Transactions] };
        }
    }
});

export const { setTransactions, newTransaction, editTransaction, deleteTransaction } = TransactionsSlice.actions;

export default TransactionsSlice.reducer;