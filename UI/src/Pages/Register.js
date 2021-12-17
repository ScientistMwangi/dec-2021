import React, { useState } from "react";
import { Form, Button, Row } from 'react-bootstrap';
import { postData } from '../../src/Service';
import { Alert } from "react-bootstrap";
import { useNavigate } from "react-router";

const Register =()=>{

    const navigate = useNavigate();
    const [user, setUser] = useState({});
    const [isAuth, setIsAuth] = useState(false);
    const [passMisMatch, setPassMisMatch] = useState(false);
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");
    const [isvalid, setValid] = useState(false);
    const [isvalidEmail, setIsvalidEmail] = useState(true);
    const [errorMessage, setErrorMessage] = useState("");

    const regex = /^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;
  
    const isValidEmailAddress =(email) => {
        return regex.test(email);
    }

    const submitForm = (e) => {
        if (email == "" || password == "" || confirmPassword == "") {
            setValid(true)
            return;
        }
        // passaword match
        if(password !== confirmPassword){
            setPassMisMatch(true);
            return;
        }
        // valid email
        if(!isValidEmailAddress(email)){
            setIsvalidEmail(false);
            return;
        }

        setPassMisMatch(false);
        setValid(false)

        var payload = { 'email': email, 'password': password };
        postData('api/auth/register', payload).then(response => {
            const data = response.data;
            //console.log(data);
            if (data.success) {
                navigate("/registered");
            } else {
                setErrorMessage(data.message);
            }
        });
        e.preventDefault();
    }



    return(
        <>
            <section id="scroll">
                <div className="container px-5">
                    <div className="row gx-5 align-items-center">
                        <Form>
                            <h4> Register </h4>
                            {passMisMatch && (<Alert variant='danger'>
                                Password does not match
                            </Alert>)}
                            {isvalid && (<Alert variant='danger'>
                                Please fill all the fields
                            </Alert>)}
                            {errorMessage !== "" && (<Alert variant='danger'>
                                {errorMessage}
                            </Alert>)}
                            {!isvalidEmail && (<Alert variant='danger'>
                               Please enter a valid email address
                            </Alert>)}
                            <Form.Group className="mb-3" controlId="formBasicEmail">
                                <Form.Label>Email address</Form.Label>
                                <Form.Control className="w-50" type="email" onChange={(e) => setEmail(e.target.value)} placeholder="Enter email" />
                            </Form.Group>

                            <Form.Group className="mb-3" controlId="formBasicPassword">
                                <Form.Label>Password</Form.Label>
                                <Form.Control className="w-50" type="password" placeholder="Password" onChange={(e) => setPassword(e.target.value)} />
                            </Form.Group>
                            <Form.Group className="mb-3" controlId="formBasicPassword">
                                <Form.Label>Password</Form.Label>
                                <Form.Control className="w-50" type="password" placeholder="confirm Password" onChange={(e) => setConfirmPassword(e.target.value)} />
                            </Form.Group>
                            <Button variant="secondary" onClick={submitForm}>
                                Submit
                            </Button>
                        </Form>

                    </div>
                </div>
            </section>
        </>
    );
}
export default Register;