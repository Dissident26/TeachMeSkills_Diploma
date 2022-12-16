import React, { useCallback, useState } from "react";

import {
  GetPostResponse,
  GetUserResponse,
  useGetCommentsByPostId,
} from "../../api";
import { Spinner } from "../spinner";
import { useRecursiveComments } from "./use-recursive-comments";

interface CommentsSectionProps {
  post?: GetPostResponse;
  users: Record<number, GetUserResponse>;
}

export const CommentsSection = ({ post, users }: CommentsSectionProps) => {
  const [showComments, setShowComments] = useState(false);
  const buttonMessage = showComments ? "Hide" : "Show"; //make separate file for all strings
  const {
    data,
    isLoading,
    refetch: refetchComments,
  } = useGetCommentsByPostId(post?.id);

  const { comments } = useRecursiveComments(data, users);

  const handleCLick = useCallback(() => {
    setShowComments((prevState) => !prevState);
    refetchComments();
  }, [post?.id]);

  if (isLoading) {
    return <Spinner />;
  }

  return (
    <div>
      <button
        onClick={handleCLick}
      >{`${buttonMessage} comments (${post?.commentsCount})`}</button>
      {showComments && <div>{comments}</div>}
    </div>
  );
};
