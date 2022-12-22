import React from "react";
import { useQuery } from "react-query";
import { getCommentsListByPostId } from "../../requests";
import { QueryKey } from "../query-key";

export const useGetCommentsByPostId = (id?: number) =>
  useQuery({
    queryKey: [QueryKey.GetCommentsByPostId, id],
    queryFn: () => getCommentsListByPostId(id),
    enabled: false,
  });
