import React, { useMemo } from "react";

import {
  GetCommentListResponse,
  GetCommentResponse,
  GetUserResponse,
} from "../../api";

import { Comment } from "../comment";

type RepliedCommentsMap = Record<number, GetCommentResponse>;

export const useRecursiveComments = (
  comments?: GetCommentListResponse,
  users?: Record<number, GetUserResponse>
) => {
  const commentsMap = useMemo(
    () =>
      comments?.reduce((acc, curr) => {
        acc[curr.id] = curr;

        return acc;
      }, {} as RepliedCommentsMap),
    [comments]
  );

  // переделать бэк на то чтобы исходный коммент хранил массив с ид дочерних комментов

  const addRepliedComments = (comment: GetCommentResponse) => {
    const user = users[comment?.userId];
    if (!comment?.repliedCommentId) {
      return <Comment user={user} comment={comment} />;
    } else {
      const originalComment = commentsMap[comment?.repliedCommentId];
      const originalUser = users[originalComment?.userId];

      return (
        <Comment user={originalUser} comment={originalComment}>
          {addRepliedComments(comment)}
          {/* <Comment user={user} comment={comment} /> */}
        </Comment>
      );
    }
  };

  const commentsWithReplies = useMemo(
    () =>
      comments?.map((comment) => {
        if (comment.repliedCommentId) {
          return;
        }
        return addRepliedComments(comment);
      }),
    [comments]
  );

  return {
    comments: commentsWithReplies,
  };
};
