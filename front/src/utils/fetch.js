import axios from 'axios';
import storage from './storage';
import { BASE_URL } from './constants';

// eslint-disable-next-line import/prefer-default-export
export const fetch = async (endpoint, method, data, options = { ContentType: 'application/json' }) => {
  const token = storage.get('token');
  const URL = `${BASE_URL}/${endpoint}`;
  
  console.log("URL",URL);

  const headers = {
    'Content-Type': options.ContentType,
  };
  if (token) {
    headers.Authorization = `Bearer ${token}`;
  }
  return axios({
    url: URL,
    method,
    headers,
    data,
  });
};
