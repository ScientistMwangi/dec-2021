import React,{useEffect, useState} from 'react';
import {Button} from 'react-bootstrap';
import { getData } from '../Service';
import {useTokenContext} from '../Store/AppContext';
import  AddProductModal from '../Componets/Modals/AddProductModal';


const Products =()=>{

    //Context
    const token = useTokenContext();
    // Local state
    const [productItems, setProductItems] = useState();
    const[show, setShow] = useState(false);
    const hideModal=()=>{
        setShow(false);
    }

    useEffect(() => {
        getData("api/system-configs/get-products-params", setProductItems, token);
    }, [show]);

    return(

     <div className='container'>
        <Button className="btn" variant="warning" onClick={setShow}> Add</Button>
        <AddProductModal show={show} hideModal ={hideModal}/>
        <h4 className='mb-4'>Product</h4>
        <table className='table table-bordered table-hover table-responsive-sm'>
          <thead>
            <tr>
            <th scope='col'>#</th>
            <th scope='col'>Product Name</th>
            <th scope='col'>Category Name</th>
            <th scope='col'>Quantity</th>
            <th scope='col'>SoldOut</th>
            <th scope='col'>Price per item(Ksh)</th>
            <th scope='col'>Actions</th>
          </tr>
          </thead>
          <tbody>
              {
                productItems && productItems.map((item)=>{
                        return(
                            <tr>
                            <td>{item.id}</td>
                            <td>{item.name}</td>
                            <td>{item.category}</td>
                            <td>{item.quantity}</td>
                            <td>{item.soldOut}</td>
                            <td>{item.pricePerItem} </td>
                            <td>Action</td>
                            </tr>
                        )
                  })
              }
          </tbody>
        </table>
      </div>
    );
}
export default Products;