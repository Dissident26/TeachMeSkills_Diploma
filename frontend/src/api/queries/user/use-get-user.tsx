import { QueryKey, useQuery, UseQueryResult } from "react-query";

import { getUser, GetUserResponse } from "../..";
import { queryKeys } from "../query-keys";

export const useGetUser = (id?: number) =>
  useQuery({
    queryKey: [queryKeys.GetUser, id],
    queryFn: () => getUser(id),
    enabled: !!id,
  });
