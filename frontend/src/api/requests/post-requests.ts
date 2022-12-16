import { urls } from "../../constants/urls";
import { api } from "../api";
import { PostListDto, PostDto } from "../dtos";

export const getPostsList = async (): Promise<PostListDto> => {
  const response = await api.get(urls.Post.GetList);

  return response.data;
};

export const getPost = async (id: number): Promise<PostDto> => {
  const response = await api.get(`${urls.Post.Get}/${id}`);

  return response.data;
};
