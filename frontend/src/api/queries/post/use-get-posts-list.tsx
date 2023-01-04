import { useQuery, UseQueryResult } from "react-query";

import { PostListDto, getPostsList } from "../..";
import { QueryKey } from "../query-key";

export const useGetPostsList = () =>
  useQuery({
    queryKey: [QueryKey.GetPostsList],
    queryFn: getPostsList,
  }) as UseQueryResult<PostListDto>;
