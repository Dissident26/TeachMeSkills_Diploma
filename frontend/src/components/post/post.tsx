import React, { FunctionComponent } from "react";

import { GetPostResponse, GetUserResponse } from "../../api";
import { CommentsSection } from "../comment";
import { UserSection } from "../user";

import styles from "./styles.module.scss";

interface PostProps {
  data: GetPostResponse;
  users: Record<number, GetUserResponse>;
}

export const Post: FunctionComponent<PostProps> = ({
  data,
  users,
}: PostProps) => {
  const { id, content, creationDate, userId } = data;

  return (
    <div className={styles.container}>
      <div key={id}>
        <UserSection user={users[userId]} />
        <p>{content}</p>
        <p>Created: {creationDate.toString()}</p>
        <CommentsSection postId={id} users={users} />
      </div>
    </div>
  );
};

//user section
//tags section
//content section
//info section
