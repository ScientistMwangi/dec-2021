import React,{ useState}  from "react";
import {  useCartContentContext, useTokenContext , useUpdateCartContentContext} from "../Store/AppContext";
import ShowMyOrders from "../Componets/ShowMyOders";
import { Alert } from 'react-bootstrap';
import { postData } from '../Service';
import {useNavigate} from 'react-router-dom';

const OrderProcess =()=>{

    const navigate = useNavigate();
    // Use context
    const cartContent = useCartContentContext();
    const token = useTokenContext();
    const updateCart = useUpdateCartContentContext();
    //local state
    const [loading, setLoading] = useState(false);
    const [errorMessage, setErrorMessage] = useState("");
    // Send to the backend
    const confirmOrder =()=>{

        setErrorMessage("")
        setLoading(true);
        postData('api/order/confirm-order', cartContent, token).then(response => {
            const data = response.data;
            setLoading(false)
            //console.log(data);
            if (data.success) {
                updateCart([]);
                navigate("/myorders");
            } else {
                setErrorMessage(data.message);
            }
        }).catch(error => {
            console.log(error);
            setErrorMessage("An error occurred while submitting please contact system admin!");
            setLoading(false);
         });
    }

    let total = 0;
    for (let index = 0; index < cartContent.length; index++) {
        total += cartContent[index].pricePerItem;
        
    }
    const bgStyle = {
            backgroundColor:'white'
    };

   return(
    <>
    <div className="container px-5" style={bgStyle} >
                <p>{'  '}{loading ? "saving..." : ""}</p>
                {errorMessage !== "" && (<Alert variant='danger'> {errorMessage}</Alert>)}
     <h4 className='mb-4'>Product Categories</h4>
      <table className='table table-bordered table-hover table-responsive-sm'>
        <thead>
          <tr>
            <th scope='col'>Product Name</th>
            <th scope='col'>Quantity</th>
            <th scope='col'>Price per item(Ksh)</th>
            <th scope='col'>Actions</th>
          </tr>
        </thead>
        {
            cartContent && cartContent.map((product, index)=>{
               return( product && <ShowMyOrders  product={product}/>)

            })
        }
        <tbody>
        </tbody>
        </table>
        </div>
        <div className="container px-5" style={bgStyle} >
            <h4  className='mb-4'>Total Price$: {total}</h4>
        <button  onClick={confirmOrder} type="button"  class="btn btn-warning btn-lg btn-block">
           PROCEED TO CHECKOUT
        </button>
        </div>
        </>
   );
}
export default OrderProcess;