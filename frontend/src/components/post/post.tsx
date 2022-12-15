import React, { FunctionComponent } from "react";

import { GetPostResponse, GetUserResponse } from "../../api";
import { UserSection } from "../user";

import styles from "./styles.module.scss";

interface PostProps {
  data: GetPostResponse;
  user: GetUserResponse;
}

export const Post: FunctionComponent<PostProps> = ({
  data,
  user,
}: PostProps) => {
  const { id, content, creationDate } = data;

  return (
    <div className={styles.container}>
      <div key={id}>
        <UserSection user={user} />
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
