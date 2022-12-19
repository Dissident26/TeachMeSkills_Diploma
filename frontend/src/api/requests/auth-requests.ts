import { urls } from "../../constants/urls";
import { api } from "../api";
import { UserAuthRequestDto } from "../dtos";

export const signIn = async (authData: UserAuthRequestDto): Promise<string> => {
  const response = await api.post(`${urls.Authorization.SignIn}`, {
    ...authData,
  });

  return response.data;
};

export const signUp = async (authData: UserAuthRequestDto): Promise<string> => {
  const response = await api.post(`${urls.Authorization.SignUp}`, {
    ...authData,
  });

  return response.data;
};
