import { useQuery, UseQueryResult } from "react-query";

import { PostListDto, getPostListByTag } from "../..";
import { QueryKey } from "../query-key";

export const useGetPostsListByTag = (id?: number) =>
  useQuery({
    queryKey: [QueryKey.GetPostsListByTag, id],
    queryFn: () => getPostListByTag(id),
    enabled: !!id,
  }) as UseQueryResult<PostListDto>;
