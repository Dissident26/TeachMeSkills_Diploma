import React, { useCallback } from "react";
import { Form, Spinner, SubmitButton, TextArea } from "..";
import { CommentDto, useCreateRepliedCommentMutation } from "../../api";

import styles from "./styles.module.scss";

const CONTENT_INPUT_NAME = "content";

interface ReplyCommentFormProps {
  comment?: CommentDto;
  refetchComments?: () => void;
}

export const ReplyCommentForm = ({
  comment,
  refetchComments,
}: ReplyCommentFormProps) => {
  const { mutateAsync, isLoading } = useCreateRepliedCommentMutation({
    onSuccess: refetchComments,
  });
  const handleSubmit = useCallback(
    async (data: CommentDto) => {
      const commentModel: CommentDto = {
        ...comment,
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
