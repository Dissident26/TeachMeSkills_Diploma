import React from "react";

import { useGetPostsList, PostDto } from "../../api";
import { Spinner } from "../spinner";
import { Post } from "./post";

export const AllPosts = () => {
  const { isLoading: isPostsLoading, data: posts } = useGetPostsList();

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
