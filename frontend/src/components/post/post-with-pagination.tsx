import React, { useState } from "react";
import { useParams } from "react-router-dom";

import { useGetPostsListByPage, PostDto } from "../../api";
import { Spinner } from "../spinner";
import { usePostPagesNavButtons } from "./hooks";
import { Post } from "./post";

export const PostWithPagination = () => {
  const { page } = useParams();
  const currentPage = Number(page);

  const { isLoading: isPostsLoading, data } =
    useGetPostsListByPage(currentPage);
  const pageNavButtons = usePostPagesNavButtons(data?.pages, currentPage);

  if (isPostsLoading) {
    return <Spinner />;
  }

  return (
    <>
      {data?.posts.map((post: PostDto) => (
        <Post key={post.id} post={post} />
      ))}
      {pageNavButtons}
    </>
  );
};
