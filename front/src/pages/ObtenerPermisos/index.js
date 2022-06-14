import React,{useEffect,useState} from 'react';
import {Link} from "react-router-dom";
import {Table,Container,Button} from "react-bootstrap";
import { Permisos } from '../../services/Permisos';
import './ObtenerPermisos.css';

const ObtenerPermisos = () => {

  const [permisos,setPermisos]=useState([]);

  const getPermisos=async ()=>{
    const listaPermisos=await Permisos.get();
    setPermisos(listaPermisos);
  }

  useEffect(()=>{
    getPermisos();
  },[]);


  return(
  <Container fluid className="cover">
  <Table striped bordered hover>
  <thead>
    <tr>      
      <th>Nombre del empleado</th>
      <th>Apellido del empleado</th>
      <th>Tipo de permiso</th>
      <th>&nbsp;</th>
    </tr>
  </thead>
  <tbody>

    
      {
        permisos.map((permiso, i) =>{          
          return (
            <tr key={permiso.id.toString()}>     
              <td>{permiso.nombreEmpleado}</td>
              <td>{permiso.apellidoEmpleado}</td>
              <td>{permiso.tipoPermiso.descripcion}</td>
              <td className='d-flex justify-content-center'>
                <Button as={Link} href="#solicitarpermiso" to={"/modificarpermiso/"+permiso.id+"/"+permiso.nombreEmpleado+"/"+permiso.apellidoEmpleado+"/"+permiso.tipoPermiso.id} className="button">
                    Modificar
                </Button>
              </td>
            </tr>  
          );        

        })
        
       }     

    


  </tbody>
</Table>
</Container>);
};

ObtenerPermisos.propTypes = {};

ObtenerPermisos.defaultProps = {};

export default ObtenerPermisos;
