import React, { useMemo } from "react";

import {
  GetCommentListResponse,
  GetCommentResponse,
  GetUserResponse,
} from "../../api";

import { Comment } from "../comment";

export const useRecursiveComments = (
  comments?: GetCommentListResponse,
  users?: Record<number, GetUserResponse>
) => {
  const addRepliedComments = (comment: GetCommentResponse) => {
    const user = users[comment?.userId];
    if (!comment?.repliedComments) {
      return <Comment user={user} comment={comment} />;
    }

    return (
      <Comment user={user} comment={comment}>
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
