import React, { useCallback, useState } from "react";

import { PostDto, useGetCommentsByPostId } from "../../api";
import { DateSection, Link, Spinner } from "..";
import { CommentsButton } from "./comments-button";
import { useComments } from "./use-comments";

import styles from "./styles.module.scss";

interface CommentsSectionProps {
  post?: PostDto;
}

export const CommentsSection = ({ post }: CommentsSectionProps) => {
  const [isCommentsVisible, setIsCommentsVisible] = useState(false);

  const {
    data,
    isLoading,
    refetch: refetchComments,
  } = useGetCommentsByPostId(post?.id);

  const { comments } = useComments(data);

  const handleCLick = useCallback(() => {
    setIsCommentsVisible((prevState) => !prevState);
    refetchComments();
  }, [post?.id]);

  if (isLoading) {
    return <Spinner />;
  }

  return (
    <div>
      <CommentsButton
        isCommentsVisible={isCommentsVisible}
        commentsCount={post?.commentsCount}
        onClick={handleCLick}
      />
      <Link to={`post/${post?.id}`}>link</Link>
      <DateSection date={post?.creationDate} />
      {isCommentsVisible && <div>{comments}</div>}
    </div>
  );
};
