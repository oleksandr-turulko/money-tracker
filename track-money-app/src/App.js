import React, { useState } from 'react';
import './App.css';
import HomePage from './components/HomePage';
import { BrowserRouter,Route,Navigate,Routes} from 'react-router-dom';
import { useSelector } from 'react-redux';
import SignInPage from './components/SignInPage';
import SignUpPage from './components/SignUpPage';

function App() {
  const {isLoggedIn}=useSelector(state=>state.authenticationSlice);
  return (
    <BrowserRouter>
      <Routes>
        <Route
          path="/"
          element={isLoggedIn ? <HomePage /> : <SignInPage />}
        />
        <Route
          path="/sign-in"
          element={isLoggedIn ? <Navigate to="/" /> : <SignInPage />}
        />
        <Route
          path="/sign-up"
          element={isLoggedIn ? <Navigate to="/" /> : <SignUpPage />}
        />
        <Route path="*" element={<h2>Page not found</h2>} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
