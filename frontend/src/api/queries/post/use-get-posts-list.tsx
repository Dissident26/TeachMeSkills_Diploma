import { useQuery, UseQueryResult } from "react-query";

import { getPostsList, PostPageDto } from "../..";
import { QueryKey } from "../query-key";

export const useGetPostsList = () =>
  useQuery({
    queryKey: [QueryKey.GetPostsList],
    queryFn: getPostsList,
  }) as UseQueryResult<PostPageDto>;
