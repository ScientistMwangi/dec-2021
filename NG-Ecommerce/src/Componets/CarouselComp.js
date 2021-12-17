import React from "react";
import { Carousel } from "react-bootstrap";
const CarouselComp=()=>{
    return(
        <>
        <Carousel>
        <Carousel.Item>
            <img
            className="d-block w-100"
            src="../assests/image3.jpg"
            alt="First slide"
            />
            <Carousel.Caption>
            <h3>Amazing X-Mas Deals!</h3>
            <p>Get up to 50% discount</p>
            </Carousel.Caption>
        </Carousel.Item>
        <Carousel.Item>
            <img
            className="d-block w-100"
            src="../assests/image3.jpg"
            alt="Second slide"
            />

            <Carousel.Caption>
            <h3>Amazing X-Mas Deals!</h3>
            <p>Free Delivery!</p>
                </Carousel.Caption>
            </Carousel.Item>
            <Carousel.Item>
                <img
                className="d-block w-100"
                src="../assests/image3.jpg"
                alt="Third slide"
                />

                <Carousel.Caption>
                <h3>Amazing X-Mas Deals!</h3>
                <p>Chance To win yourself a goat!</p>
                </Carousel.Caption>
            </Carousel.Item>
            </Carousel>

        </>
    );
}
export default CarouselComp;