import React from "react";

import { Button } from "..";

interface CommentsButtonProps {
  isCommentsVisible: boolean;
  commentsCount: number;
  onClick: () => void;
}

export const CommentButton = ({
  isCommentsVisible,
  commentsCount,
  onClick,
}: CommentsButtonProps) => {
  const buttonMessage = isCommentsVisible ? "Hide" : "Show";

  return (
    <Button
      value={`${buttonMessage} comments (${commentsCount})`}
      onClick={onClick}
    />
  );
};
