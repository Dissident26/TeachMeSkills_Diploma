import React, { ReactNode } from "react";
import { CommentDto, UserDto } from "../../api";
import { UserSection } from "../user";

import styles from "./styles.module.scss";

interface CommentProps {
  comment: CommentDto;
  user?: UserDto;
  children?: ReactNode;
}

export const Comment = ({ comment, user, children }: CommentProps) => {
  return (
    <>
      <div className={styles.container}>
        <div>{comment?.content}</div>
        <div>{comment?.creationDate.toString()}</div>
        <UserSection user={user} />
      </div>
      <div className={styles.childrenContainer}>{children}</div>
    </>
  );
};
