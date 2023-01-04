import React from "react";
import { useParams } from "react-router-dom";

import { PostDto, useGetPostsListByTag } from "../../api";
import { Spinner } from "../spinner";
import { Post } from "./post";

export const PostListByTag = () => {
  const { id } = useParams();
  const { isLoading: isPostsLoading, data: posts } = useGetPostsListByTag(
    Number(id)
  );

  if (isPostsLoading) {
    return <Spinner />;
  }

  return (
    <>
      {posts?.map((post: PostDto) => (
        <Post key={post.id} post={post} />
      ))}
    </>
  );
};
