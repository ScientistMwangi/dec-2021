import React from 'react';
import { Button } from 'react-bootstrap'; 
import { useCartContentContext, useUpdateCartContentContext, useUpdateTokenContext } from '../Store/AppContext';


const ShowMyOrders = (props)=>{
    const cartContext = useCartContentContext();
    const updateCartContext = useUpdateCartContentContext();
    const onDeleteClick =(uuid)=>{
         updateCartContext([...cartContext.filter(x => x.uuid !== uuid)]);
    }
    const bgStyle = {
        backgroundColor:'#f68b1e'
    }
    return(
        <tr>
            <td>{props.product && props.product.name}</td>
            <td>{props.product && props.product.quantity}</td>
            <td>{props.product && props.product.pricePerItem}</td>
            <td>
            <Button onClick={() => onDeleteClick(props.product && props.product.uuid)} className="btn" variant="warning" style={bgStyle}> Remove
            </Button>
            </td>
        </tr>
    )
}
export default ShowMyOrders;