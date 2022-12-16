import { urls } from "../../constants/urls";
import { api } from "../api";
import { UserDto } from "../dtos";

export const getUser = async (id?: number): Promise<UserDto> => {
  const response = await api.get(`${urls.User.Get}/${id}`);

  return response.data;
};

export const getUsersByIds = async (ids?: number[]): Promise<UserDto[]> => {
  const response = await api.post(`${urls.User.GetByIds}`, {
    ids,
  });

  return response.data;
};
