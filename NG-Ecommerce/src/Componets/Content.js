import React from 'react';
import Product from './Product';

const Content =(props)=>{

    return (
        <>
         {
            props.products && props.products.map((product, index)=>{
                return(<section id="scroll">
                <div className="container px-5" id={index}>
                    <div className="row gx-5 align-items-center">
                        <Product product={props.products[index]}/>
                    </div>
                    </div>
                </section>)
            }) 
         }
        </>
    );
}
export default Content;