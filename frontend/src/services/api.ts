import axios from "axios";

/**
 * Axios instance configured for API calls to the backend.
 * Base URL points to the local development server.
 */
export const api = axios.create({
  baseURL: "http://localhost:5197/api",
});
