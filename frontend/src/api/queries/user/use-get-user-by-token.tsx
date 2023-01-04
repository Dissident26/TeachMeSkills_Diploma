import { useQuery } from "react-query";

import { getUserByToken } from "../..";
import { QueryKey } from "../query-key";

export const useGetUserByToken = () =>
  useQuery({
    queryKey: [QueryKey.GetUserByToken],
    queryFn: getUserByToken,
    enabled: false,
  });
