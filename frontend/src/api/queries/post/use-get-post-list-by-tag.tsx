import { useQuery, UseQueryResult } from "react-query";

import { PostListDto, getPostListByTag } from "../..";
import { queryKeys } from "../query-keys";

export const useGetPostsListByTag = (id?: number) =>
  useQuery({
    queryKey: [queryKeys.GetPostsListByTag, id],
    queryFn: () => getPostListByTag(id),
    enabled: !!id,
  }) as UseQueryResult<PostListDto>;
