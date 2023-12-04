import { configureStore } from '@reduxjs/toolkit';
import expensesReducer from './expenses/expensesReducer';
import authSlice from './auth/authSlice';

export const store = configureStore({
  reducer: {
    expensesReducer:expensesReducer,
    authenticationSlice:authSlice
  },  
});
