import React, { useCallback, useMemo, useState } from "react";

import { CommentListDto, CommentDto } from "../../api";

import { Comment } from ".";

export const useComments = (
  comments?: CommentListDto,
  refetchComments?: () => void
) => {
  const [selectedCommentId, setSelectedCommentId] = useState<number>(null);
  const [editedCommentId, setEditedCommentId] = useState<number>(null);

  const handleSelectComment = useCallback(
    (id?: number) => {
      const commentId = selectedCommentId === id ? null : id;
      setSelectedCommentId(commentId);
      setEditedCommentId(null);
    },
    [setSelectedCommentId, setEditedCommentId]
  );

  const handleEditComment = useCallback(
    (id?: number) => {
      const commentId = editedCommentId === id ? null : id;
      setSelectedCommentId(null);
      setEditedCommentId(commentId);
    },
    [setSelectedCommentId, setEditedCommentId]
  );

  const handleResetState = useCallback(() => {
    setSelectedCommentId(null);
    setEditedCommentId(null);
  }, [setSelectedCommentId, setEditedCommentId]);

  const addRepliedComments = (comment: CommentDto) => {
    const isReplyVisible = selectedCommentId === comment.id;
    const isEditing = editedCommentId === comment.id;

    const props = {
      key: comment.id,
      user: comment.user,
      comment,
      isReplyVisible,
      setIsReplyVisible: () => handleSelectComment(comment.id),
      isEditing,
      setIsEditing: () => handleEditComment(comment.id),
      refetchComments,
      handleResetState,
    };

    if (!comment?.repliedComments) {
      return <Comment {...props} />;
    }

    return (
      <Comment {...props}>
        {comment?.repliedComments.map((comment) => addRepliedComments(comment))}
      </Comment>
    );
  };

  const commentsWithReplies = useMemo(
    () => comments?.map((comment) => addRepliedComments(comment)),
    [comments, selectedCommentId, editedCommentId]
  );

  return {
    comments: commentsWithReplies,
  };
};
