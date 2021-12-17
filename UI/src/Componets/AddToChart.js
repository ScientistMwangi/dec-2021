import React from 'react';
import {  useCartContentContext, useUpdateCartContentContext  } from '../Store/AppContext';

const AddToChart = (props) => {
    const cartContent = useCartContentContext();
    const updateCartContent = useUpdateCartContentContext();
    
    const handleAddToChart =()=>{
        const {id, name, imageUrl, pricePerItem, quantity} = props.props;
        var newProduct = { 'uuid': Date.now(), 'id':id,'name':name, 'imageUrl': imageUrl, 
        'pricePerItem': pricePerItem, 'quantity':1};
        updateCartContent([...cartContent, newProduct]);
    }
    return (
        <button type="button" onClick={handleAddToChart} class="btn btn-warning btn-lg btn-block">
            ADD TO CART
        </button>
    )
}
export default AddToChart;