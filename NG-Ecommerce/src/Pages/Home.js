import React  from "react";
import CarouselComp from '../Componets/CarouselComp';
import Content from '../Componets/Content';
import { Pagination } from 'react-bootstrap';
import { useState, useEffect } from 'react';
import { getPaginatedData } from './../Service';

const Home =(props)=>{


    const[currentPage, setCurrentPage] = useState(1);
    const[lastPage, setLastPage] = useState(9);
  
  
    const handlePageNation1 =()=>{
        if(currentPage > 1){
          setCurrentPage(currentPage => currentPage -1);
        }
    }
  
    const handlePageNation2 =()=>{
      if(products.pageCount >= currentPage + 1){
        setCurrentPage(currentPage => currentPage +1);
      }
    }
  
    const [products, setProducts] = useState();
    useEffect(() => {
      getPaginatedData("api/system-configs/get-products", setProducts, currentPage);
  
    }, [currentPage]);



    return (
        <>
        <CarouselComp/>
        <Content products={products && products.results2}/>
        <section>
            <div className="container px-5" >
              <div className="row gx-5 align-items-center">
                <div className="col-lg-4 order-lg-1">
                </div>
                <div className="col-lg-4 order-lg-1" align-items-center>

                  <nav aria-label='Page navigation example'>
                    <ul className='pagination mb-0'>
                    <Pagination>
                      <Pagination.Item onClick={handlePageNation1} >Prev</Pagination.Item>

                      <Pagination.Item  active>{currentPage}</Pagination.Item>


                      <Pagination.Item onClick={handlePageNation2} >Next</Pagination.Item>

                    </Pagination>
                    </ul>
                  </nav>

                </div>
                <div className="col-lg-4 order-lg-1">
                </div>
              </div>
            </div>
          </section>
        </>);
}
export default Home;