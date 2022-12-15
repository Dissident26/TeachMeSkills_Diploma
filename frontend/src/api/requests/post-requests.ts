import { urls } from "../../constants/urls";
import { api } from "../api";
import { GetPostListResponse, GetPostResponse } from "../response-models";

export const getPostsList = async (): Promise<GetPostListResponse> => {
  const response = await api.get(urls.Post.GetList);

  return response.data;
};

export const getPost = async (id: number): Promise<GetPostResponse> => {
  const response = await api.get(`${urls.Post.Get}/${id}`);

  return response.data;
};
