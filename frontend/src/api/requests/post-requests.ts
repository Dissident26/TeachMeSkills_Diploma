import { urls } from "../../constants/urls";
import { api } from "../api";
import { PostDto, PostPageDto } from "../dtos";

export const getPostsList = async (): Promise<PostPageDto> => {
  const response = await api.get(urls.post.new);

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

export const createPost = async (post: Partial<PostDto>): Promise<PostDto> => {
  const response = await api.post(`${urls.post.create}`, {
    ...post,
  });

  return response.data;
};

export const getPostsListByPage = async (
  page: number
): Promise<PostPageDto> => {
  const response = await api.get(`${urls.post.getByPage}/${page}`);

  return response.data;
};
