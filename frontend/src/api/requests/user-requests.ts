import { urls } from "../../constants/urls";
import { api } from "../api";
import { GetUserResponse } from "../response-models";

export const getUser = async (id?: number): Promise<GetUserResponse> => {
  const response = await api.get(`${urls.User.Get}/${id}`);

  return response.data;
};
