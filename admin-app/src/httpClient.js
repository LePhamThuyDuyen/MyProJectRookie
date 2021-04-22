import axios from 'axios'

const instance = axios.create({
    baseURL: "https://leduyenshop.azurewebsites.net",
  });
  export default instance;