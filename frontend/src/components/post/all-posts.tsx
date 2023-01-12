import React, { Fragment } from "react";

import { useGetPostsList, PostDto } from "../../api";
import { Spinner } from "../spinner";
import { usePostPagesNavButtons } from "./hooks";
import { Post } from "./post";

export const AllPosts = () => {
  const { isLoading: isPostsLoading, data } = useGetPostsList();
  const pageNavButtons = usePostPagesNavButtons(data?.pages);

  if (isPostsLoading) {
    return <Spinner />;
  }

  return (
    <>
      {data?.posts.map((post: PostDto) => (
        <Post post={post} key={post.id} />
      ))}
      {pageNavButtons}
    </>
  );
};
