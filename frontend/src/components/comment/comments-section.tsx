import React, { useCallback, useState } from "react";

import {
  GetCommentResponse,
  GetUserResponse,
  useGetCommentsByPostId,
} from "../../api";
import { Spinner } from "../spinner";
import { Comment } from "./";
import { useRecursiveComments } from "./use-recursive-comments";

interface CommentsSectionProps {
  postId?: number;
  users: Record<number, GetUserResponse>;
}

export const CommentsSection = ({ postId, users }: CommentsSectionProps) => {
  const [showComments, setShowComments] = useState(false);
  const {
    data,
    isLoading,
    refetch: refetchComments,
  } = useGetCommentsByPostId(postId);

  const { comments } = useRecursiveComments(data, users);

  const handleCLick = useCallback(() => {
    setShowComments((prevState) => !prevState);
    refetchComments();
  }, [postId]);

  if (isLoading) {
    return <Spinner />;
  }

  return (
    <div>
      <button onClick={handleCLick}>Show comments</button>
      {showComments && <div>{comments}</div>}
    </div>
  );
};
