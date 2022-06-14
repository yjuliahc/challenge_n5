import  {fetch}  from '../utils/fetch';

const get = async() => {
  try {
      const { data } = await fetch('api/TipoPermisos', 'get')
      return data
    } catch (e) {
      return Promise.reject(e)
    }
}



export const TipoPermisos = {
    get,   
}