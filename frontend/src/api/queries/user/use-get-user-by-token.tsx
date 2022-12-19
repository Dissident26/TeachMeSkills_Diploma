import { useQuery } from "react-query";

import { getUserByToken } from "../..";
import { queryKeys } from "../query-keys";

export const useGetUserByToken = () =>
  useQuery({
    queryKey: [queryKeys.GetUserByToken],
    queryFn: getUserByToken,
    enabled: false,
  });
