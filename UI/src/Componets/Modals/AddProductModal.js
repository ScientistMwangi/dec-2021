import React, { useState, useEffect } from "react";
import { Modal, Button, Alert, FormGroup, Form } from 'react-bootstrap';
import { postData } from '../../Service';
import { useTokenContext } from '../../Store/AppContext';
import { useNavigate } from 'react-router-dom';
import { getData } from "../../Service";

const AddProductModal = (props) => {

    // react-router
    const navigate = useNavigate();
    // Get Token from context
    const token = useTokenContext();


    const handleCategory = (e) => {
        setCategoryId(e);
    }

    // Form values
    const test = () => {
        console.log("test err");
        setLoading(!loading)
    }
    // local state
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const [isvalid, setValid] = useState(false);
    const [fileName, setFileName] = useState(null);
    const [loading, setLoading] = useState(false);
    const [name, setName] = useState();
    const [category, setCategory] = useState();
    const [categoryId, setCategoryId] = useState();
    const [categories, setCategories] = useState();
    const [description, setDescription] = useState();
    const [quantity, setQuantity] = useState();
    const [pricePerItem, setPricePerItem] = useState();

    const [errorMessage, setErrorMessage] = useState("");
    const handleImageChange = (e) => {
        console.log(e);
        if (!e.target.files || e.target.files.length === 0) {
            setFileName(undefined);
          return;
        }
    
        // I've kept this example simple by using the first image instead of multiple
        setFileName(e.target.files[0]);
      };


    const submitForm = (e) => {
        e.preventDefault();
        const formData = new FormData();
        formData.append("name", name);
        formData.append("quantity", parseFloat(quantity));
        formData.append("pricePerItem",  parseFloat(pricePerItem));
        formData.append("formFile", fileName);
        formData.append("ProductCategoryId", categoryId);
        formData.append("description", description);
        console.log(formData);
        console.log(fileName);

        if (name == "" || description == "") {
            setValid(true)
            return;
        }
        setValid(false)
        setErrorMessage("")
        var payload = {
            'name': name, 'description': description, 'ProductCategoryId': parseInt(categoryId),
            'pricePerItem': parseFloat(pricePerItem), 'quantity': parseFloat(quantity),
            'formFile': fileName
        };
        console.log(payload);
        setLoading(true);
        postData('api/system-configs/add-product', formData, token).then(response => {
            const data = response.data;
            setLoading(false)
            //console.log(data);
            if (data.success) {
                //setCategory("");
                // setDescription("");
                props.hideModal();
                navigate("/products");
            } else {
                setErrorMessage(data.message);
            }
        }).catch(error => {
            console.log(error);
            setErrorMessage("An error occurred while submitting please contact system admin!");
            setLoading(false);
        });
    }

    // Get categories
    useEffect(() => {
        getData("api/system-configs/get-category", setCategories, token);
        if(categories){
            setCategoryId(categories[0].id);
        }
        
    }, []);

    return (
        
        <Modal show={props.show} onHide={handleClose}>
            <form onSubmit={submitForm}>
            <Modal.Header>
                <Modal.Title>
                    <p>{'  '}{loading ? "saving..." : ""}</p>
                    Add Product
                    {isvalid && (<Alert variant='danger'>
                        Please fill all the fields
                    </Alert>)
                    }
                    {errorMessage !== "" && (<Alert variant='danger'> {errorMessage}</Alert>)}


                </Modal.Title>
            </Modal.Header>
            <Modal.Body>
            
                <input type="hidden" name="id" />
                <div className="form-group">
                    <label for="exampleInputPassword1">Name</label>
                    <input onChange={(e) => setName(e.target.value)} type="text" name="name" class="form-control" id="exampleInputPassword1" placeholder="" />
                </div>
                <Form.Group controlId="formFile" className="mb-3">
                    <Form.Label>Default file input example</Form.Label>
                    <Form.Control type="file" onChange={(e) => handleImageChange(e)} />
                </Form.Group>
                <div className="form-group">
                    <label for="exampleInputPassword1">Description</label>
                    <input onChange={(e) => setDescription(e.target.value)} type="text" name="description" class="form-control" id="exampleInputPassword1" placeholder="" />
                </div>
                <div className="form-group">
                    <label for="exampleInputPassword21">Quantity</label>
                    <input number onChange={(e) => setQuantity(e.target.value)} type="text" name="quantity" class="form-control" id="exampleInputPassword1" placeholder="" />
                </div>
                <div className="form-group">
                    <label for="exampleInputPassword11">Price Per Item</label>
                    <input number onChange={(e) => setPricePerItem(e.target.value)} type="text" name="price" class="form-control" id="exampleInputPassword1" placeholder="" />
                </div>
                <div className="form-group">
                    <label for="exampleInputPassword1">Category</label>
                    <select onChange={(e) => handleCategory(e.target.value)} type="select" name="category" class="form-control" id="exampleInputPassword1" >
                    <option key="0" value="0">Select Category</option>
                        {
                            categories && categories.map((cat, index) => {
                                return (<option key={cat.id} value={cat.id}>{cat.name}</option>)
                            })
                        }
                    </select>
                </div>

           
            </Modal.Body>
            <Modal.Footer>
            <input
                type='submit'
                className='btn btn-primary'
              />
                <Button variant="secondary" onClick={props.hideModal}>
                    Close
                </Button>

            </Modal.Footer>
            </form>
        </Modal>
    )
}
export default AddProductModal;