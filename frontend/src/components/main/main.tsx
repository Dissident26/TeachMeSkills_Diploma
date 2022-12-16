import React, { FunctionComponent } from "react";
import { Post, Spinner } from "..";
import {
  GetPostResponse,
  GetUserResponse,
  useGetPostsList,
  useGetUsersByIds,
} from "../../api";

import styles from "./styles.module.scss";

export const Main: FunctionComponent = () => {
  const { isLoading: isPostsLoading, data: posts } = useGetPostsList();
  const { isLoading: isUsersLoading, data: users } = useGetUsersByIds(
    posts?.map((post) => post.userId)
  );

  const usersDictionary = users?.reduce((acc, curr) => {
    acc[curr.id] = curr;

    return acc;
  }, {} as Record<string, GetUserResponse>);

  if (isPostsLoading || isUsersLoading) {
    return <Spinner />;
  }

  return (
    users && (
      <div className={styles.container}>
        {posts?.map((post: GetPostResponse) => (
          <Post post={post} users={usersDictionary} />
        ))}
      </div>
    )
  );
};
