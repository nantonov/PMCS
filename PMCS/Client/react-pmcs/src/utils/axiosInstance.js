import axios from 'axios';
import { axiosConfig } from '../configuration/axiosConfig';
import authService from '../Services/authService';

const axiosInstance = axios.create({
  baseURL: axiosConfig.baseURL,
});

axiosInstance.interceptors.request.use (
  async function (config) {
    const token = await authService.getUser().then((user) => {
      return user.access_token;
    });
    if (token) config.headers.Authorization = `Bearer ${token}`;
    return config;
  },
  function (error) {
    return Promise.reject (error);
  }
);

export { axiosInstance };