import React from "react";

import { useParams } from "react-router-dom";
import { useGetPost } from "../../api";
import { Spinner } from "../spinner";
import { Post } from "./post";

export const SinglePost = () => {
  const { id } = useParams();
  const { data, isLoading } = useGetPost(Number(id));

  if (isLoading) {
    return <Spinner />;
  }

  return <Post post={data} />;
};
