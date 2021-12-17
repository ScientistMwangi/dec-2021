import React from 'react';
import AddToChart from './AddToChart';
const Product = (props) => {
    const bgStyle = {
        backgroundColor: 'white'
    };
    return (
        <>
            {
                props.product && props.product.map((product, index) => {
                    return (
                        <>
                            <p></p>
                            <div className="col-lg-4 order-lg-1" id={index} style={bgStyle}>
                                <div className="p-5"><img className="img-fluid" src="../assests/image2.jpg" alt="..." />
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