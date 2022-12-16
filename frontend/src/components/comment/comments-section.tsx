import React, { useCallback, useState } from "react";

import { PostDto, useGetCommentsByPostId } from "../../api";
import { Spinner } from "../spinner";
import { CommentsButton } from "./comments-button";
import { useComments } from "./use-comments";

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
      <span>{post?.creationDate.toString()}</span>
      {isCommentsVisible && <div>{comments}</div>}
    </div>
  );
};

//проблемы

//1 не грузит юзеров которые участвуют в комментах, но не в постах
//2 дохера лишних методов на БЕ
//3 пагинация
