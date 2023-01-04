import React, { useMemo, useState } from "react";

import { CommentListDto, CommentDto } from "../../api";

import { Comment } from ".";

export const useComments = (
  comments?: CommentListDto,
  refetchComments?: () => void
) => {
  const [selectedCommentId, setSelectedCommentId] = useState<number>(null);

  const handleClick = (id: number) => {
    setSelectedCommentId(!selectedCommentId ? id : null);
  };

  const addRepliedComments = (comment: CommentDto) => {
    const isReplyVisible = selectedCommentId === comment.id;
    const props = {
      key: comment.id,
      user: comment.user,
      comment,
      isReplyVisible,
      setIsReplyVisible: () => handleClick(comment.id),
      refetchComments,
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
    [comments, selectedCommentId]
  );

  return {
    comments: commentsWithReplies,
  };
};
