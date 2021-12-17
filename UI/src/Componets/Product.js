import React from 'react';
import { BASE_URL_API } from "../Store/Constants";
import AddToChart from './AddToChart';
const Product = (props) => {
    const imagePartialUrl = BASE_URL_API+"StaticFiles/";
    const bgStyle = {
        backgroundColor: 'white',       
    };
    const margin = {
        margin: '10px',       
    };
    return (
        <>
            {
                props.product && props.product.map((product, index) => {
                    return (
                        <>
                            <p></p>
                            <div className="col-lg-4 order-lg-1" id={index}  >
                                <div className="p-5"><img className="img-fluid" src={imagePartialUrl+product.imageUrl.trim()} alt="..." />
                                    <p>{product.name} | {' Price: ' + product.pricePerItem + ' $'} </p>
                                    <AddToChart props={product} />
                                </div>
                            </div>
                            <p></p>
                        </>)
                })
            }

        </>
    );
}
export default Product;