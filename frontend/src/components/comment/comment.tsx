import React, { ReactNode, useCallback } from "react";
import { CommentDto, UserDto } from "../../api";
import { UserSection, DateSection, ReplyCommentForm, Button } from "..";
import { useUserProvider } from "../../contexts";

import styles from "./styles.module.scss";
import { EditCommentForm } from "./edit-comment-form";

interface CommentProps {
  comment: CommentDto;
  user?: UserDto;
  isReplyVisible: boolean;
  setIsReplyVisible: () => void;
  isEditing: boolean;
  setIsEditing: () => void;
  handleResetState: () => void;
  refetchComments?: () => void;
  children?: ReactNode;
}

const AVATAR_SIZE = "30px";

export const Comment = ({
  comment,
  user,
  isReplyVisible,
  setIsReplyVisible,
  isEditing,
  setIsEditing,
  refetchComments,
  handleResetState,
  children,
}: CommentProps) => {
  const handleSubmit = useCallback(() => {
    refetchComments?.();
    handleResetState();
  }, [setIsReplyVisible, refetchComments, setIsEditing]);

  const { user: authUser } = useUserProvider();
  const isUserActionsAvailable = !!authUser;
  const isEditAvailable = authUser.id === comment.userId;

  return (
    <>
      <div className={styles.container}>
        {isEditing ? (
          <EditCommentForm comment={comment} onSuccess={handleSubmit} />
        ) : (
          <p className={styles.content}>{comment?.content}</p>
        )}
        <div className={styles.info}>
          <UserSection user={user} avatarSize={AVATAR_SIZE} />
          <DateSection date={comment?.creationDate} />
          {isUserActionsAvailable && (
            <>
              {isEditAvailable && (
                <Button onClick={setIsEditing} value={"Edit"} />
              )}
              <Button onClick={setIsReplyVisible} value={"Reply"} />
            </>
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
