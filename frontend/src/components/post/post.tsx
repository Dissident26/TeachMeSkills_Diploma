import React, { FunctionComponent } from "react";

import { GetPostResponse } from "../../api";
import { UserSection } from "../user";

import styles from "./styles.module.scss";

interface PostProps {
  data: GetPostResponse;
}

export const Post: FunctionComponent<PostProps> = ({ data }: PostProps) => {
  const { id, userId, content, creationDate } = data;

  return (
    <div className={styles.container}>
      <div key={id}>
        <UserSection userId={userId} />
        <p>{content}</p>
        <p>Created: {creationDate.toString()}</p>
      </div>
    </div>
  );
};

//user section
//tags section
//content section
//info section
