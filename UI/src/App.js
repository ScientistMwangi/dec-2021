import logo from './logo.svg';
import React, { useContext } from 'react'
import '../node_modules/bootstrap/dist/css/bootstrap.min.css';
import CustomNav from './Componets/CustomNav';
import Home from './Pages/Home';
import Login from './Pages/Login';
import Register from './Pages/Register';
import Order from './Pages/OrderProcess';
import Footer from './Componets/Footer';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import ProtectedRoute from './Routes/ProtectedRoute';
import MyOrders from './Pages/MyOrders';
import ConfirmEmail from './Pages/ConfirmEmail';
import CategoryPage from './Pages/Category';
import Products from './Pages/Products';
import EmailLog from './Pages/EmailLogs';
import { AppProvider } from './Store/AppContext';
import './App.css';
import "bootstrap/dist/css/bootstrap.min.css";
import OrderProcess from './Pages/OrderProcess';


const pStyle = {
  backgroundColor: '#fdedf0'
};

function App() {

  return (
    <AppProvider>
      <Router>
        <CustomNav />
        <div style={pStyle}>
          <Routes>
            <Route path="/email-logs" element={<EmailLog />} />
            <Route path="/products" element={<Products />} />
            <Route path="/categorys" element={<CategoryPage />} />
            <Route path="/" element={<Home />} />
            <Route path="/login" element={<Login />} />
            <Route path="/register" element={<Register />} />
            <Route path="/registered" element={<ConfirmEmail />} />
            <Route path="/process-orders" element={<OrderProcess />} />
            <Route path="/myorders" element={<MyOrders />} />
            <Route exact path='/admin' element={<ProtectedRoute />}>
            </Route>
          </Routes>
          <Footer />
        </div>
      </Router>
    </AppProvider>
  );
}

export default App;
