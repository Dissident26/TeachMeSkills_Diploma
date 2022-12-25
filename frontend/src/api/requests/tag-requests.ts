import { api } from "../api";

export const getTagList = async () => {
  const response = await api.get("tag/list");

  return response.data;
};
