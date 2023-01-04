import { urls } from "../../constants/urls";
import { api } from "../api";
import { UserAuthRequestDto, UserDto } from "../dtos";

export const signIn = async (authData: UserAuthRequestDto): Promise<string> => {
  const response = await api.post(`${urls.authorization.signIn}`, {
    ...authData,
  });

  return response.data;
};

export const signUp = async (authData: UserAuthRequestDto): Promise<string> => {
  const response = await api.post(`${urls.authorization.signUp}`, {
    ...authData,
  });

  return response.data;
};

export const getUserByToken = async (): Promise<UserDto> => {
  const response = await api.get(`${urls.authorization.getByToken}`);

  return response.data;
};
