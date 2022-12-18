import axios from "axios";

import { LOCAL_STORAGE_JWT_TOKEN_KEY } from "../constants";

const baseURL = "https://localhost:7048/";

export const api = axios.create({
  baseURL,
  headers: { Authorization: localStorage.getItem(LOCAL_STORAGE_JWT_TOKEN_KEY) },
});
