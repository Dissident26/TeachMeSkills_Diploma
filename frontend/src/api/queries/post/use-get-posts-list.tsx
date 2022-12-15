import { useQuery, UseQueryResult } from "react-query";

import { GetPostListResponse, getPostsList } from "../..";
import { queryKeys } from "../query-keys";

export const useGetPostsList = () =>
  useQuery({
    queryKey: [queryKeys.GetPostsList],
    queryFn: getPostsList,
  }) as UseQueryResult<GetPostListResponse>; //add types
