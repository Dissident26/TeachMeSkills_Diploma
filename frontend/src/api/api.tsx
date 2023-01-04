import axios from "axios";

import { LOCAL_STORAGE_JWT_TOKEN_KEY } from "../constants";

const baseURL = "https://localhost:7048/";
const AUTHORIZATION_HEADER = "Authorization";

const api = axios.create({
  baseURL,
});

api.interceptors.request.use((config) => {
  config.headers[AUTHORIZATION_HEADER] = `${localStorage.getItem(
    LOCAL_STORAGE_JWT_TOKEN_KEY
  )}`;
  return config;
});

export { api };
