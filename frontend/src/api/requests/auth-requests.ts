import { urls } from "../../constants/urls";
import { api } from "../api";
import { UserAuthRequestDto } from "../dtos";

export const authUser = async (
  authData: UserAuthRequestDto
): Promise<string> => {
  const response = await api.post(`${urls.Authorization.SignIn}`, {
    ...authData,
  });

  return response.data;
};
