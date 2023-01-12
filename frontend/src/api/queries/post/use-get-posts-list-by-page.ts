import { useQuery } from "react-query";
import { getPostsListByPage } from "../../requests";
import { QueryKey } from "../query-key";

export const useGetPostsListByPage = (page: number) =>
  useQuery({
    queryKey: [QueryKey.GetPostsListByPage, page],
    queryFn: () => getPostsListByPage(page),
  });
