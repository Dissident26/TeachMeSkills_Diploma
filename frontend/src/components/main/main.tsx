import React, { FunctionComponent } from "react";
import { Post, Spinner } from "..";
import { GetPostResponse, useGetPostsList } from "../../api";

import styles from "./styles.module.scss";

export const Main: FunctionComponent = () => {
  const { isLoading, data } = useGetPostsList();

  if (isLoading) {
    return <Spinner />;
  }

  data.length = 10; //add Take(10) on BE

  return (
    <>
      <div className={styles.container}>
        {data?.map((post: GetPostResponse) => (
          <Post data={post} />
        ))}
        main content
      </div>
    </>
  );
};
