import React,{useState, useEffect} from 'react';
import {useTokenContext} from '../Store/AppContext';
import { getData } from '../Service';

const MyOrders =()=>{

    //Context
    const token = useTokenContext();
    // Local state
    const [orders, setOrders] = useState();
    useEffect(() => {
        getData("api/order/my-orders", setOrders, token);
        console.log(orders);
    }, []);

    return(
        <div className='container'>    
        <h4 className='mb-4'>My Orders</h4>
        <table className='table table-bordered table-hover table-responsive-sm'>
          <thead>
            <tr>
            <th scope='col'>Order #</th>
            <th scope='col'>Name</th>
            <th scope='col'>Image</th>
            <th scope='col'>Quantity</th>
            <th scope='col'>Price per item(Ksh)</th>
            <th scope='col'>Ordered Date</th>
          </tr>
          </thead>
          <tbody>
              {
                orders && orders.listOfMyOrderDetails.map((item)=>{
                        return(
                            <tr>
                            <td>{item.id}</td>
                            <td>{item.name}</td>
                            <td>{item.imageUrl}</td>
                            <td>{item.quantity}</td>
                            <td>{item.pricePerItem} </td>
                            <td>{item.orderDate}</td>
                            </tr>
                        )
                  })
              }
          </tbody>
        </table>
      </div>
    );
}
export default MyOrders;