import { useQuery } from "react-query";

import { getPost } from "../..";
import { queryKeys } from "../query-keys";

export const useGetPost = (id?: number) =>
  useQuery({
    queryKey: [queryKeys.GetPost],
    queryFn: () => getPost(id),
    enabled: !!id,
  });
