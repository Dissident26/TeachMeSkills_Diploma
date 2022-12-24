import React, { ReactNode } from "react";
import { CommentDto, UserDto } from "../../api";
import { UserSection, DateSection, ReplyCommentForm } from "..";

import styles from "./styles.module.scss";

interface CommentProps {
  comment: CommentDto;
  user?: UserDto;
  isReplyVisible: boolean;
  setIsReplyVisible: () => void;
  children?: ReactNode;
}

const AVATAR_SIZE = "30px";

export const Comment = ({
  comment,
  user,
  isReplyVisible,
  setIsReplyVisible,
  children,
}: CommentProps) => {
  return (
    <>
      <div className={styles.container}>
        <div className={styles.content}>{comment?.content}</div>
        <div className={styles.info}>
          <UserSection user={user} avatarSize={AVATAR_SIZE} />
          <DateSection date={comment?.creationDate} />
          <button onClick={setIsReplyVisible}>Reply</button>
        </div>
        {isReplyVisible && <ReplyCommentForm comment={comment} />}
      </div>
      <div className={styles.childrenContainer}>{children}</div>
    </>
  );
};
