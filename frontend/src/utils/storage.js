const storage = {};
storage.get = () => localStorage.getItem('token');
storage.set = (token) => localStorage.setItem('token', token);
export default storage;