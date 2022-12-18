import React, { useMemo } from "react";

import { CommentListDto, CommentDto } from "../../api";

import { Comment } from ".";

export const useComments = (comments?: CommentListDto) => {
  const addRepliedComments = (comment: CommentDto) => {
    if (!comment?.repliedComments) {
      return <Comment key={comment.id} user={comment.user} comment={comment} />;
    }

    return (
      <Comment key={comment.id} user={comment.user} comment={comment}>
        {comment?.repliedComments.map((comment) => addRepliedComments(comment))}
      </Comment>
    );
  };

  const commentsWithReplies = useMemo(
    () => comments?.map((comment) => addRepliedComments(comment)),
    [comments]
  );

  return {
    comments: commentsWithReplies,
  };
};
