import  {fetch}  from '../utils/fetch';

const post = async(payload) => {
    try {
        const { data } = await fetch('api/Permisos/solicitarpermiso', 'post', payload)
        return data
      } catch (e) {             
        return Promise.reject(e)
      }
  }

const get = async() => {
try {
    const { data } = await fetch('api/Permisos/ObtenerPermisos', 'get')
    return data
    } catch (e) {
      return Promise.reject(e)
    }
}

const put = async(id,payload) => {
  try {
      const { data } = await fetch('api/Permisos/modificarpermiso/'+id, 'put', payload)
      return data
    } catch (e) {             
      return Promise.reject(e)
    }
}
  



export const Permisos = {
    post,   
    get,
    put
}