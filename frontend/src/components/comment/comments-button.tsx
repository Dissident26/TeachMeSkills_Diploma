import React from "react";

interface CommentsButtonProps {
  isCommentsVisible: boolean;
  commentsCount: number;
  onClick: () => void;
}

export const CommentsButton = ({
  isCommentsVisible,
  commentsCount,
  onClick,
}: CommentsButtonProps) => {
  const buttonMessage = isCommentsVisible ? "Hide" : "Show"; //make separate file for all strings
  //add styling & i classname lib
  return (
    <button
      onClick={onClick}
    >{`${buttonMessage} comments (${commentsCount})`}</button>
  );
};
