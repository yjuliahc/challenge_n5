import * as page from '../pages';
import Menu from '../components/layouts/Menu';


// element: isLoggedIn ? <DashboardLayout /> : <Navigate to="/login" />,
// const routes(isLoggedIn) = [
export const routes = [
  {
    path: '/',
    element: <Menu />,
    children: [
      { path: '', element: <page.SolicitarPermiso /> },
    ],
  },  {
    path: '/modificarpermiso/:id/:nombre/:apellido/:idPermiso',
    element: <Menu />,
    children: [
      { path: '', element: <page.SolicitarPermiso /> },
    ],
  },  
  {
    path: '/solicitarpermiso',
    element: <Menu />,
    children: [
      { path: '', element: <page.SolicitarPermiso /> },
    ],
  }, 
  {
    path: '/obtenerpermisos',
    element: <Menu />,
    children: [
      { path: '', element: <page.ObtenerPermisos /> },
    ],
  }, 
];