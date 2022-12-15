import axios from "axios";

const baseURL = "https://localhost:7048/";

export const api = axios.create({
  baseURL,
  timeout: 1000,
  headers: { "X-Custom-Header": "foobar" },
});
