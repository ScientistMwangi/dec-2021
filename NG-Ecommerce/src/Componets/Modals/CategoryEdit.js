import React,{useState} from 'react';
import { Modal, Button, Alert } from 'react-bootstrap';
import { postData } from '../../Service';
import {useTokenContext} from '../../Store/AppContext';
import {useNavigate} from 'react-router-dom';

const CategoryEdit =(props)=>{

    /*console.log(props);
    // react-router
    const navigate = useNavigate();
    // Get Token from context
    const token = useTokenContext();

    // local state
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const [isvalid, setValid] = useState(false);

    // Form values
    const test =()=>{
        console.log("test err");
        setLoading(!loading)
    }
    const [loading, setLoading] = useState(false);
    const [categoryId, setCategoryId] = useState(props.id);
    const [category, setCategory] = useState(props.category);
    const [description, setDescription] = useState(props.description);

    const [errorMessage, setErrorMessage] = useState("");

    const submitForm = (e) => {
        if (category == "" || description == "") {
            setValid(true)
            return;
        }
        setValid(false)
        setErrorMessage("")
        var payload = { 'id': categoryId, 'name': category, 'description': description };
        setLoading(true);
        postData('api/system-configs/edit-category', payload, token).then(response => {
            const data = response.data;
            setLoading(false)
            //console.log(data);
            if (data.success) {
                setCategory("");
                setDescription("");
                props.hideModal();
                navigate("/categorys");
            } else {
                setErrorMessage(data.message);
            }
        }).catch(error => {
            console.log(error);
            setErrorMessage("An error occurred while submitting please contact system admin!");
            setLoading(false);
         });
        e.preventDefault();
    }
    */

    return(
        <Modal show={props.show} >
            <Modal.Header>
            <Modal.Title>               
                Edit Category
            </Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <input type="hidden" name="id"/>
                <div className="form-group">
                    <label for="exampleInputPassword1">Name</label>
                    <input onChange={()=>{console.log()}} type="text"name="name" class="form-control" id="exampleInputPassword1" placeholder=""/>
                </div> 
                <div className="form-group">
                    <label for="exampleInputPassword1">Description</label>
                    <input onChange={()=>{console.log()}}  type="text"name="description" class="form-control" id="exampleInputPassword1" placeholder=""/>
                </div> 

            </Modal.Body>
            <Modal.Footer>
            <Button variant="secondary" onClick={props.hideModal}>
                Close
            </Button>
            <Button variant="primary" onClick={()=>{console.log()}}>
                Save Changes
            </Button>
            
            </Modal.Footer>
        </Modal>
    )
}
export default CategoryEdit;