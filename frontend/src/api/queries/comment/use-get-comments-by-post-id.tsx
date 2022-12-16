import React from "react";
import { useQuery } from "react-query";
import { getCommentsListByPostId } from "../../requests";
import { queryKeys } from "../query-keys";

export const useGetCommentsByPostId = (id?: number) =>
  useQuery({
    queryKey: [queryKeys.GetCommentsByPostId, id],
    queryFn: () => getCommentsListByPostId(id),
    enabled: false,
  });
