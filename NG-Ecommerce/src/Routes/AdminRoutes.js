import React from 'react';
import {Outlet, Navigate  } from 'react-router-dom';
import { useAuthContext, useIsAdminContext } from '../Store/AppContext';
function AdminRoutes({isAuth1: isAuth1, component:component, ...rest}){
    const isAdmin = useIsAdminContext();
    const isAuth = useAuthContext();
    if(isAuth && isAdmin){
        return <Outlet />;
    }else if(isAuth){
        return <Navigate to="/" />;
    }else{
        <Navigate to="/login" />
    }
} 
export default AdminRoutes;