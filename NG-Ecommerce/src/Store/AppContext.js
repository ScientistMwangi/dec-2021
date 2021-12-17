import React, { useState, useContext, useEffect } from 'react';

// Create context
const AuthContext = React.createContext();
const AuthUpdateContext = React.createContext();

const IsAdminContext = React.createContext();
const IsAdminUpdateContext = React.createContext();

const UserNameContext = React.createContext();
const UserNameUpdateContext = React.createContext();

const TokenContext = React.createContext();
const TokenUpdateContext = React.createContext();

/*const CartCountContext = React.createContext();
const CartCountUpdateContext = React.createContext();*/

const CartContentContext = React.createContext();
const CartContentUpdateContext = React.createContext();


// Export custom hook context to be used on other components
export function useAuthContext() {
    return useContext(AuthContext);
}
export function useAuthUpdateContext() {
    return useContext(AuthUpdateContext);
}

export function useIsAdminContext() {
    return useContext(IsAdminContext);
}
export function useIsAdminUpdateContext() {
    return useContext(IsAdminUpdateContext);
}

export function useUserNameContext() {
    return useContext(UserNameContext);
}
export function useUpdateUserNameContext() {
    return useContext(UserNameUpdateContext);
}
export function useTokenContext() {
    return useContext(TokenContext);
}
export function useUpdateTokenContext() {
    return useContext(TokenUpdateContext);
}
/*
export function useCartCountContext() {
    return useContext(CartContentContext);
}
export function useUpdateCartCountContext() {
    return useContext(CartCountUpdateContext);
}
*/
export function useCartContentContext() {
    return useContext(CartContentContext);
}
export function useUpdateCartContentContext() {
    return useContext(CartContentUpdateContext);
}



export function AppProvider({ children }) {

    const [isAuth, setIsAuth] = useState(()=>{
        const localData = localStorage.getItem("isAuth");
        const value =  JSON.parse(localData);
        return value || false;
    });
    const [isAdmin, setIsAdmin] = useState(()=>{
        const localData = localStorage.getItem("isAdmin");
        const value =  JSON.parse(localData);
        return value || false;
    });
    const [userName, setUserName] = useState(()=>{
        const localData = localStorage.getItem("userName");
        return localData ? JSON.parse(localData) : "";
    });
    const [token, setToken] = useState(()=>{
        const localData = localStorage.getItem("token");
        return localData ? JSON.parse(localData) : "";
    });

    /*const[cartCount, setCartCount] = useState(()=>{
        const localData = localStorage.getItem("cartCount");
        return localData ? JSON.parse(localData) : 0;
    });*/
    const[cartContent, setCartContent] =useState(()=>{
        const localData = localStorage.getItem("cartContent");
        return localData ? JSON.parse(localData) : [];
    });
    
    function updateAuth(value) {
        setIsAuth(value);
    }
    function updateIsAdmin(value) {
        setIsAdmin(value);
    }
    function updateUserName(value) {
        setUserName(value);
    }
    function updateToken(value) {
        setToken(value);
    }

    /*function updateCartCount(value) {
        setCartCount(value);
    }*/
    function updateCartContent(value) {
        setCartContent(value);
    }


    // Use local storage
    useEffect(()=>{
        localStorage.setItem("isAuth", JSON.stringify(isAuth));
    },[isAuth]);
    useEffect(()=>{
        localStorage.setItem("isAdmin", JSON.stringify(isAdmin));
    },[isAdmin]);
    useEffect(()=>{
        localStorage.setItem("userName", JSON.stringify(userName));
    },[userName]);
    useEffect(()=>{
        localStorage.setItem("token", JSON.stringify(token));
    },[token]);

    /*useEffect(()=>{
        localStorage.setItem("cartCount", JSON.stringify(cartCount));
    },[cartCount]);
*/
    useEffect(()=>{
        localStorage.setItem("cartContent", JSON.stringify(cartContent));
    },[cartContent]);

    return (
        <AuthContext.Provider value={isAuth}>
            <AuthUpdateContext.Provider value={updateAuth}>
                <IsAdminContext.Provider value={isAdmin}>
                    <IsAdminUpdateContext.Provider value={updateIsAdmin}>
                        <UserNameContext.Provider value ={userName}>
                            <UserNameUpdateContext.Provider value ={updateUserName}>
                                <TokenContext.Provider value ={token}>
                                <TokenUpdateContext.Provider value={updateToken}>
                                    <CartContentContext.Provider value={cartContent}>
                                        <CartContentUpdateContext.Provider value={updateCartContent}>

                                                    {children}

                                        </CartContentUpdateContext.Provider>
                                    </CartContentContext.Provider>

                                </TokenUpdateContext.Provider>
                                </TokenContext.Provider>
                                </UserNameUpdateContext.Provider>
                                </UserNameContext.Provider>
                            </IsAdminUpdateContext.Provider>
                        </IsAdminContext.Provider>
                    </AuthUpdateContext.Provider>
                </AuthContext.Provider>
                )
}