import React,{useState} from 'react';
import { Modal, Button, Alert } from 'react-bootstrap';
import { postData } from '../../Service';
import {useTokenContext} from '../../Store/AppContext';
import {useNavigate} from 'react-router-dom';

const CategoryModal =(props)=>{

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
    const [category, setCategory] = useState();
    const [description, setDescription] = useState();

    const [errorMessage, setErrorMessage] = useState("");

    const submitForm = (e) => {
        if (category == "" || description == "") {
            setValid(true)
            return;
        }
        setValid(false)
        setErrorMessage("")
        var payload = { 'name': category, 'description': description };
        setLoading(true);
        postData('api/system-configs/add-category', payload, token).then(response => {
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
    

    return(
        <Modal show={props.show} onHide={handleClose}>
            <Modal.Header>
            <Modal.Title>
                <p>{'  '}{loading ? "saving..." : ""}</p>
                Category
                {isvalid && (<Alert variant='danger'>
                                Please fill all the fields
                            </Alert>)
                }
                {errorMessage !== "" && (<Alert variant='danger'> {errorMessage}</Alert>)}
                

            </Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <input type="hidden" name="id"/>
                <div className="form-group">
                    <label for="exampleInputPassword1">Name</label>
                    <input onChange={(e)=>setCategory(e.target.value)} type="text"name="name" class="form-control" id="exampleInputPassword1" placeholder=""/>
                </div> 
                <div className="form-group">
                    <label for="exampleInputPassword1">Description</label>
                    <input onChange={(e)=>setDescription(e.target.value)}  type="text"name="description" class="form-control" id="exampleInputPassword1" placeholder=""/>
                </div> 

            </Modal.Body>
            <Modal.Footer>
            <Button variant="secondary" onClick={props.hideModal}>
                Close
            </Button>
            <Button variant="primary" onClick={submitForm}>
                Save Changes
            </Button>
            
            </Modal.Footer>
        </Modal>
    )
}
export default CategoryModal;