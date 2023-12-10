import { createSlice } from '@reduxjs/toolkit';

export const statisticsSlice = createSlice({
    name: 'statistics',
    initialState: {
        transactionAmountPerCategory: [],
    },
    reducers: {
        setTransactionAmountPerCategory: (state, action) => {
            return { ...state, transactionAmountPerCategory: [...action.payload] };
        },
    }
});

export const { setTransactionAmountPerCategory } = statisticsSlice.actions;

export default statisticsSlice.reducer;