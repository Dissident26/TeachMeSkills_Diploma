import { urls } from "../../constants";
import { api } from "../api";

export const getTagList = async () => {
  const response = await api.get("tag/list");

  return response.data;
};

export const getSuggestedTags = async (input: string) => {
  const response = await api.get(`${urls.tag.getSuggestedTags}/${input}`);

  return response.data;
};
