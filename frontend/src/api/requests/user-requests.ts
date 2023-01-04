import { urls } from "../../constants/urls";
import { api } from "../api";
import { UserDto } from "../dtos";

export const getUser = async (id?: number): Promise<UserDto> => {
  const response = await api.get(`${urls.user.get}/${id}`);

  return response.data;
};
