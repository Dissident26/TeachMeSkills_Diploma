import React, { ReactNode } from "react";
import { CommentDto, UserDto } from "../../api";
import { UserSection, DateSection } from "..";

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
        <div className={styles.content}>{comment?.content}</div>
        <div className={styles.info}>
          <UserSection user={user} avatarSize="30px" />
          <DateSection date={comment?.creationDate} />
        </div>
      </div>
      <div className={styles.childrenContainer}>{children}</div>
    </>
  );
};
