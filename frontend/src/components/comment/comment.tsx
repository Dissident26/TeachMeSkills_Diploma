import React, { ReactNode, useCallback } from "react";
import { CommentDto, UserDto } from "../../api";
import { UserSection, DateSection, ReplyCommentForm } from "..";

import styles from "./styles.module.scss";
import { useUserProvider } from "../../contexts";

interface CommentProps {
  comment: CommentDto;
  user?: UserDto;
  isReplyVisible: boolean;
  setIsReplyVisible: () => void;
  refetchComments?: () => void;
  children?: ReactNode;
}

const AVATAR_SIZE = "30px";

export const Comment = ({
  comment,
  user,
  isReplyVisible,
  setIsReplyVisible,
  refetchComments,
  children,
}: CommentProps) => {
  const handleSubmit = useCallback(() => {
    refetchComments?.();
    setIsReplyVisible();
  }, [setIsReplyVisible, refetchComments]);

  const { user: authUser } = useUserProvider();
  const isReplySectionAvailable = !!authUser;

  return (
    <>
      <div className={styles.container}>
        <div className={styles.content}>{comment?.content}</div>
        <div className={styles.info}>
          <UserSection user={user} avatarSize={AVATAR_SIZE} />
          <DateSection date={comment?.creationDate} />
          {isReplySectionAvailable && (
            <button onClick={setIsReplyVisible}>Reply</button>
          )}
        </div>
        {isReplyVisible && (
          <ReplyCommentForm comment={comment} onSuccess={handleSubmit} />
        )}
      </div>
      <div className={styles.childrenContainer}>{children}</div>
    </>
  );
};
