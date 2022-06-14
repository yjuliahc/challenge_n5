import React, { useEffect, useState } from 'react';
import {Form,Button,Card} from "react-bootstrap";
import {TipoPermisos} from "../../services/TipoPermisos";
import {Permisos} from "../../services/Permisos";
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

import './SolicitarPermiso.css';
import { useParams } from 'react-router-dom';

const SolicitarPermiso = () => {

  const [permiso,setPermiso]=useState([]);
  const params = useParams();
  const [title,setTitle]=useState("Solicitar permiso");

  const [datos, setDatos] = useState({
    NombreEmpleado: '',
    ApellidoEmpleado: ''
  })


  useEffect(()=>{      
      if(params.id!=null)
      {
        setTitle("Modicar permiso");
        setDatos({id:params.id,tipoPermisoId:params.idPermiso,NombreEmpleado:params.nombre,ApellidoEmpleado:params.apellido});
      }
  },[]);

  const getTipoPermisos=async ()=>{
    const data=await TipoPermisos.get();    
    setPermiso(data);
  }
  

  const handleInputChange = (event) => {    
    setDatos({
        ...datos,
        [event.target.name] : event.target.value
    })
  }
  

  const enviarDatos = async (event) => {
    event.preventDefault()               
    try
    {
      if(!datos.id)
      {        
        await Permisos.post(datos);
      }else{
        await Permisos.put(datos.id,datos);
      }
      toast.success("Permiso guardado")
    }catch(exception)
    {
      if(exception.response.data.hasOwnProperty("errors"))
      {        
        const errores=exception.response.data.errors;
        let errorData="";
        for(const error in errores)
        {
          errorData+=errores[error].join(", ")+". ";
        }
        toast.error(errorData);
      }else
      {
        toast.error(exception.response.data);
      } 
      
    }
  }

  useEffect(()=>{
    getTipoPermisos();
  },[]);
  
  return(<div className="d-flex justify-content-center">
   <ToastContainer />
  <Card style={{ width: '25rem' }} className="mt-3">
  <Card.Title className="d-flex justify-content-center mt-3">
  <p className="text-secondary header">{title}</p>
  </Card.Title>
  <Card.Body className="pt-4 pb-4 px-5">
  <Form onSubmit={enviarDatos}>
  <Form.Group className="mb-3" controlId="formNombre">
    <Form.Label>Nombre del empleado</Form.Label>
    <Form.Control name="NombreEmpleado" type="text" value={datos.NombreEmpleado} onChange={handleInputChange} placeholder="Nombre del empleado" />    
  </Form.Group>

  <Form.Group className="mb-3" controlId="formApellido">
    <Form.Label >Apellido del empleado</Form.Label>
    <Form.Control name="ApellidoEmpleado"  type="text" value={datos.ApellidoEmpleado} onChange={handleInputChange} placeholder="Apellido del empleado" />    
  </Form.Group>

  <Form.Group className="mb-3" controlId="formPermiso">
    <Form.Label >Permiso</Form.Label>
    <Form.Select aria-label="Default select example" name="tipoPermisoId" value={datos.tipoPermisoId} onChange={handleInputChange}>      
    <option className='titleOption' value="">Selecciona el tipo de permiso</option>
      {
        permiso.map((item, i) =>{
        
          return (
            <option key={i} value={item.id}>{item.descripcion}</option>
          );        

        })
        
       }     
    </Form.Select>
  </Form.Group>

  
  <Button className="mb-3 button" variant="primary" type="submit">
    Solicitar
  </Button>
</Form>
</Card.Body>
</Card>
</div>);


};


export default SolicitarPermiso;
