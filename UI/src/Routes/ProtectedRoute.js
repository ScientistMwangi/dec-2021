import React from 'react';
import {Outlet, Navigate  } from 'react-router-dom';
import { useAuthContext } from '../Store/AppContext';
function ProtectedRoute({isAuth1: isAuth1, component:component, ...rest}){
    const isAuth = useAuthContext();
    return isAuth ? <Outlet /> : <Navigate to="/" />;
} 
export default ProtectedRoute;