import { useQuery } from "react-query";

import { getUsersByIds } from "../..";
import { queryKeys } from "../query-keys";

export const useGetUsersByIds = (ids?: number[]) =>
  useQuery({
    queryKey: [queryKeys.GetUser, ids],
    queryFn: () => getUsersByIds(ids),
    enabled: !!ids,
  });
