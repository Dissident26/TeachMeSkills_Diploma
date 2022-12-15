import { useQuery, UseQueryResult } from "react-query";

import { getPost, GetPostResponse } from "../..";
import { queryKeys } from "../query-keys";

export const useGetPost = (id?: number) =>
  useQuery({
    queryKey: [queryKeys.GetPost],
    queryFn: () => getPost(id),
    enabled: !!id,
  });
