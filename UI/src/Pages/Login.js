import React, { useState } from "react";
import { Form, Button, Row } from 'react-bootstrap';
import { postData } from '../../src/Service';
import { Alert } from "react-bootstrap";
import { useNavigate } from "react-router";
import { useAuthUpdateContext ,useIsAdminUpdateContext,
    useUpdateUserNameContext, useUpdateTokenContext
 } from '../Store/AppContext';

const Login = () => {

    // Use context
    const changeAuth = useAuthUpdateContext();
    const updateIsAdmin = useIsAdminUpdateContext();
    const updateCurrentUser = useUpdateUserNameContext();
    const updateToken = useUpdateTokenContext();

    // Redirection react router
    const navigate = useNavigate();

    // Local state
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [isLoading, setIsLoading] = useState(false);

    const [isvalid, setValid] = useState(false);
    const [errorMessage, setErrorMessage] = useState("");

    const submitForm = (e) => {
        if (email == "" || password == "") {
            setValid(true)
            return;
        }
        setValid(false)
        setErrorMessage("")
        var payload = { 'email': email, 'password': password };
        setIsLoading(true);
        postData('api/auth/login', payload).then(response => {
            const data = response.data;
            console.log(data);
            setIsLoading(false);
            if (data.success) {
                // update user context
                changeAuth(true);
                updateToken(data.token);
                updateCurrentUser(data.username);
                data.role === 'Admin' ? updateIsAdmin(true):updateIsAdmin(false);
                navigate("/");
            } else {
                setErrorMessage(data.message);
            }
        }).catch(error => {
            console.log(error);
            setErrorMessage("An error occurred while submitting please contact system admin!");
            setIsLoading(false);
         })
        e.preventDefault();
    }


    return (
        <>
            <section id="scroll">
                <div className="container px-5">
                    <div className="row gx-5 align-items-center">
                        <Form>
                            <h4> Login </h4>
                            {isvalid && (<Alert variant='danger'>
                                Please fill all the fields
                            </Alert>)}
                            {errorMessage !== "" && (<Alert variant='danger'>
                             {errorMessage}
                            </Alert>)}
                            <Form.Group className="mb-3" controlId="formBasicEmail">
                                <Form.Label>Email address</Form.Label>
                                <Form.Control className="w-50" type="email" onChange={(e) => setEmail(e.target.value)} placeholder="Enter email" />
                            </Form.Group>

                            <Form.Group className="mb-3" controlId="formBasicPassword">
                                <Form.Label>Password</Form.Label>
                                <Form.Control className="w-50" type="password" placeholder="Password" onChange={(e) => setPassword(e.target.value)} />
                            </Form.Group>
                            <Button variant="secondary" onClick={submitForm}>
                                Submit
                            </Button>
                            {'  '}{isLoading ? "Loading..." : ""}
                        </Form>

                    </div>
                </div>
            </section>

        </>
    );
}
export default Login;