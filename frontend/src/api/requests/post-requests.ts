import { urls } from "../../constants/urls";
import { api } from "../api";
import { PostListDto, PostDto } from "../dtos";

export const getPostsList = async (): Promise<PostListDto> => {
  const response = await api.get(urls.post.getList);

  return response.data;
};

export const getPost = async (id: number): Promise<PostDto> => {
  const response = await api.get(`${urls.post.get}/${id}`);

  return response.data;
};

export const getPostListByTag = async (id: number): Promise<PostDto[]> => {
  const response = await api.get(`${urls.post.getPostListByTag}/${id}`);

  return response.data;
};
// rework
export const createPost = async (post: PostDto): Promise<PostDto> => {
  const response = await api.post(`${urls.post.create}`, {
    ...post, //лучше возвращать id
  });

  return response.data;
};
