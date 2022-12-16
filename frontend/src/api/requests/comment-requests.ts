import { urls } from "../../constants/urls";
import { api } from "../api";
import { CommentListDto } from "../dtos";

export const getCommentsListByPostId = async (
  id?: number
): Promise<CommentListDto> => {
  const response = await api.get(`${urls.Comment.GetListByPostId}/${id}`);

  return response.data;
};
