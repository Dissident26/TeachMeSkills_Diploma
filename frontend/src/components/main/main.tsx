import React, { FunctionComponent } from "react";
import { Post, Spinner } from "..";
import { PostDto, useGetPostsList } from "../../api";

import styles from "./styles.module.scss";

export const Main: FunctionComponent = () => {
  const { isLoading: isPostsLoading, data: posts } = useGetPostsList();

  if (isPostsLoading) {
    return <Spinner />;
  }

  return (
    <div className={styles.container}>
      {posts?.map((post: PostDto) => (
        <Post post={post} />
      ))}
    </div>
  );
};
