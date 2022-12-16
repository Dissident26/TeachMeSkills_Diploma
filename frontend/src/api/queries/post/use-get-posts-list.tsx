import { useQuery, UseQueryResult } from "react-query";

import { PostListDto, getPostsList } from "../..";
import { queryKeys } from "../query-keys";

export const useGetPostsList = () =>
  useQuery({
    queryKey: [queryKeys.GetPostsList],
    queryFn: getPostsList,
  }) as UseQueryResult<PostListDto>;
