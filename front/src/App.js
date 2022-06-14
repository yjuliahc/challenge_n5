import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import {useRoutes} from "react-router-dom";
import {routes} from "./routes";



const App = () => {
  const routing = useRoutes(routes);
  return routing
};

export default App;

