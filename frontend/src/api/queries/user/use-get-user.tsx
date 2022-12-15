import { useQuery } from "react-query";

import { getUser } from "../..";
import { queryKeys } from "../query-keys";

export const useGetUser = (id?: number) =>
  useQuery({
    queryKey: [queryKeys.GetUser, id],
    queryFn: () => getUser(id),
    enabled: !!id,
  });
