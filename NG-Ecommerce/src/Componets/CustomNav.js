import React from "react";
import { Navbar, Container, Nav, Button, NavDropdown, Badge } from 'react-bootstrap';
import { useNavigate } from "react-router-dom";
import { useAuthContext, useAuthUpdateContext, useIsAdminContext,useIsAdminUpdateContext,
    useUserNameContext,useUpdateUserNameContext, useUpdateTokenContext,useUpdateCartContentContext,useCartContentContext
    
 } from '../Store/AppContext';

export default function CustomNav() {

    // Use context
    const isAuth = useAuthContext(); 
    const changeAuth = useAuthUpdateContext();
    const isAdmin = useIsAdminContext(); 
    const updateIsAdmin = useIsAdminUpdateContext();
    const currentUser = useUserNameContext(); 
    const updateCurrentUser = useUpdateUserNameContext();
    const updateToken = useUpdateTokenContext();
    const updateCartContent = useUpdateCartContentContext();
    const cartContent = useCartContentContext();
  

    const navigate = useNavigate();

    const handleShowCart=()=>{
        navigate('/process-orders');
    }
    const onLogin = () =>{ 
      let path = `/login`; 
      navigate(path);
    }
    const onLogout =()=>{
        localStorage.clear();
        changeAuth(false);
        updateIsAdmin(false);
        updateCurrentUser("");
        updateToken("");
        navigate('/');
        updateCartContent([]);
        
    }

    const onRegister = () =>{ 
        let path = `/register`; 
        navigate(path);
      }

    return(
        <>
          <Navbar bg="dark" variant="dark">
            <Container>
            <Navbar.Brand href="/">NG-eCommerce</Navbar.Brand>
            <Nav className="me-auto">
            <Nav.Link href="/">Home</Nav.Link>
            {isAuth && (<Nav.Link href="/myorders">My Orders</Nav.Link> )}
               
            </Nav>
        {
            isAuth && isAdmin && (
                 <NavDropdown
                id="nav-dropdown-dark-example"
                title="Manage"
                menuVariant="dark"
                >
                <NavDropdown.Item href="/categorys">Category</NavDropdown.Item>
                <NavDropdown.Item href="#">Tags</NavDropdown.Item>
                <NavDropdown.Item href="/products">Product</NavDropdown.Item>
                <NavDropdown.Item href="/email-logs">Email Logs</NavDropdown.Item>
                </NavDropdown>
                )
        }


            <Navbar.Collapse className="justify-content-end">
                {
                    isAuth && (<button type="button" className="btn btn-warning" onClick={handleShowCart}>
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-cart" viewBox="0 0 16 16">
                      <path d="M0 1.5A.5.5 0 0 1 .5 1H2a.5.5 0 0 1 .485.379L2.89 3H14.5a.5.5 0 0 1 .491.592l-1.5 8A.5.5 0 0 1 13 12H4a.5.5 0 0 1-.491-.408L2.01 3.607 1.61 2H.5a.5.5 0 0 1-.5-.5zM3.102 4l1.313 7h8.17l1.313-7H3.102zM5 12a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm7 0a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm-7 1a1 1 0 1 1 0 2 1 1 0 0 1 0-2zm7 0a1 1 0 1 1 0 2 1 1 0 0 1 0-2z"/>
                    </svg>
                    {
                        cartContent.length > 0 &&(cartContent.length)
                    }
                    </button>)
                }
                {' '} |
                {
                    !isAuth && (<Button variant="secondary" onClick={onLogin}> Login</Button>
                    )
                }
                {' '} | 
                {
                    !isAuth && (<Button variant="secondary" onClick={onRegister}> Sign Up</Button>
                    )
                }
                
                <Navbar.Text>
                {isAuth && ("Login as: "+currentUser)}
                {' '} | 
                {
                    isAuth && (<Button variant='secondary' onClick={onLogout}> Log Out</Button>)
                }
                 {' '}   
                </Navbar.Text>
                
            </Navbar.Collapse>
            </Container>
        </Navbar>
        </>
    );
}