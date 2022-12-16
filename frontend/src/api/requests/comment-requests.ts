import { urls } from "../../constants/urls";
import { api } from "../api";
import { GetCommentListResponse } from "../response-models";

export const getCommentsListByPostId = async (
  id?: number
): Promise<GetCommentListResponse> => {
  const response = await api.get(`${urls.Comment.GetListByPostId}/${id}`);

  return response.data;
};
