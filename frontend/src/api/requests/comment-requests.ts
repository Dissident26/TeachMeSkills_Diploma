import { urls } from "../../constants/urls";
import { api } from "../api";
import { CommentDto, CommentListDto } from "../dtos";

export const getCommentsListByPostId = async (
  id?: number
): Promise<CommentListDto> => {
  const response = await api.get(`${urls.comment.getListByPostId}/${id}`);

  return response.data;
};

export const createPostComment = async (
  data: CommentDto
): Promise<CommentDto> => {
  const response = await api.post(`${urls.comment.createPostComment}`, {
    ...data,
  });

  return response.data;
};

export const createRepliedComment = async (
  data: CommentDto
): Promise<CommentDto> => {
  const response = await api.post(`${urls.comment.createRepliedComment}`, {
    ...data,
  });

  return response.data;
};
