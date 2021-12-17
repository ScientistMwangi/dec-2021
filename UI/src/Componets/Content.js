import React from 'react';
import Product from './Product';

const Content =(props)=>{
    const bgStyle = {
        backgroundColor: 'white', 
        marginUp : '5px',
        marginBottom : '5px'           
    };
    return (
        <>
         {
            props.products && props.products.map((product, index)=>{
                return(<section id="scroll">
                <div className="container px-5" id={index} style={bgStyle}>
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