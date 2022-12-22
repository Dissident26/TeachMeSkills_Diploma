import { useQuery } from "react-query";

import { getPost } from "../..";
import { QueryKey } from "../query-key";

export const useGetPost = (id?: number) =>
  useQuery({
    queryKey: [QueryKey.GetPost, id],
    queryFn: () => getPost(id),
    enabled: !!id,
  });
