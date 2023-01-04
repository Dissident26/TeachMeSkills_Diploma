import React, { useCallback } from "react";
import { Form, Spinner, SubmitButton, TextArea } from "..";
import { CommentDto, useCreatePostCommentMutation } from "../../api";

import styles from "./styles.module.scss";

const CONTENT_INPUT_NAME = "content";

interface ReplyFormProps {
  comment?: CommentDto;
  refetchComments?: () => void;
}

export const ReplyPostForm = ({ comment, refetchComments }: ReplyFormProps) => {
  const { mutateAsync, isLoading } = useCreatePostCommentMutation({
    onSuccess: refetchComments,
  });
  const handleSubmit = useCallback(
    async (data: CommentDto) => {
      const commentModel: CommentDto = {
        postId: comment.postId,
        ...data,
      };

      await mutateAsync(commentModel);
    },
    [comment]
  );

  if (isLoading) {
    return <Spinner />;
  }

  return (
    <Form onSubmit={handleSubmit}>
      <TextArea
        className={styles.textArea}
        name={CONTENT_INPUT_NAME}
        required
      />
      <SubmitButton />
    </Form>
  );
};
