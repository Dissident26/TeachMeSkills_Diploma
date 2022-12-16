import React, { ReactNode } from "react";
import { GetCommentResponse, GetUserResponse } from "../../api";
import { UserSection } from "../user";

import styles from "./styles.module.scss";

interface CommentProps {
  comment: GetCommentResponse;
  user?: GetUserResponse;
  children?: ReactNode;
}

export const Comment = ({ comment, user, children }: CommentProps) => {
  return (
    <div className={styles.container}>
      <UserSection user={user} />
      <div>{comment?.content}</div>
      <div>{comment?.creationDate.toString()}</div>
      {children}
    </div>
  );
};
