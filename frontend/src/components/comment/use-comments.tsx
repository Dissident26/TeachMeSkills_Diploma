import React, { useMemo, useState } from "react";

import { CommentListDto, CommentDto } from "../../api";

import { Comment } from ".";

export const useComments = (comments?: CommentListDto) => {
  const [selectedCommentId, setSelectedCommentId] = useState<number>(null);

  const handleClick = (id: number) => {
    setSelectedCommentId(!selectedCommentId ? id : null);
  };

  const addRepliedComments = (comment: CommentDto) => {
    const isReplyVisible = selectedCommentId === comment.id;

    if (!comment?.repliedComments) {
      return (
        <Comment
          key={comment.id}
          user={comment.user}
          comment={comment}
          isReplyVisible={isReplyVisible}
          setIsReplyVisible={() => handleClick(comment.id)}
        />
      );
    }

    return (
      <Comment
        key={comment.id}
        user={comment.user}
        comment={comment}
        isReplyVisible={isReplyVisible}
        setIsReplyVisible={() => handleClick(comment.id)}
      >
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
