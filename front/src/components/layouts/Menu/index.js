import './Menu.css';
import {Navbar,Nav,Container} from "react-bootstrap";
import { Outlet,Link } from "react-router-dom";

const Menu=()=>(
    <>
    <Navbar className="color-nav shadow-sm" variant="dark">
    <Container>
    <Navbar.Brand href="https://n5now.com/es/">N5</Navbar.Brand>
    <Nav className="me-auto">
        <Nav.Link as={Link} to="/solicitarpermiso" href="#solicitarpermiso">Solicitar permiso</Nav.Link>
        <Nav.Link as={Link} to="/obtenerpermisos" href="#obtenerpermisos">Obtener permisos</Nav.Link>
        {/*<Nav.Link as={Link} to="/modificarpermiso" href="#modificarpermiso">Modificar permiso</Nav.Link>*/}        
    </Nav>
    </Container>
    </Navbar>
    
        <Outlet></Outlet>
    
  </>
);

export default Menu;