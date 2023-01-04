import React, { useCallback, useState } from "react";

import { CommentDto, PostDto, useGetCommentsByPostId } from "../../api";
import { DateSection, Link, ReplyPostForm, Spinner } from "..";
import { CommentButton } from "./comment-button";
import { useComments } from "./use-comments";
import { generatePath } from "react-router-dom";
import { routes } from "../../routes";

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

  const { comments } = useComments(data, refetchComments);

  const handleCLick = useCallback(() => {
    setIsCommentsVisible((prevState) => !prevState);
    refetchComments();
  }, [post?.id]);

  const pathToPost = generatePath(routes.post.get, {
    id: post?.id,
  });

  if (isLoading) {
    return <Spinner />;
  }

  return (
    <div>
      <CommentButton
        isCommentsVisible={isCommentsVisible}
        commentsCount={post?.commentsCount}
        onClick={handleCLick}
      />
      <Link to={pathToPost}>link</Link>
      <DateSection date={post?.creationDate} />
      {isCommentsVisible && (
        <div>
          {comments}
          <ReplyPostForm
            comment={{ postId: post?.id } as CommentDto}
            refetchComments={refetchComments}
          />
        </div>
      )}
    </div>
  );
};
