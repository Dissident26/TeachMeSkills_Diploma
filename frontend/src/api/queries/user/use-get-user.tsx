import { useQuery } from "react-query";

import { getUser } from "../..";
import { QueryKey } from "../query-key";

export const useGetUser = (id?: number) =>
  useQuery({
    queryKey: [QueryKey.GetUser, id],
    queryFn: () => getUser(id),
    enabled: !!id,
  });
