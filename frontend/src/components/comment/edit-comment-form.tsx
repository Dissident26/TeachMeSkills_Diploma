import React, { useCallback } from "react";
import { Form, Spinner, SubmitButton, TextArea } from "..";
import { CommentDto, useUpdatePostCommentMutation } from "../../api";

import styles from "./styles.module.scss";

interface EditCommentFormProps {
  comment: CommentDto;
  onSuccess?: () => void;
}

const INPUT_NAME = "content";

export const EditCommentForm = ({
  comment,
  onSuccess,
}: EditCommentFormProps) => {
  const { mutateAsync, isLoading } = useUpdatePostCommentMutation({
    onSuccess,
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
        defaultValue={comment?.content}
        className={styles.textArea}
        name={INPUT_NAME}
        required
      />
      <SubmitButton />
    </Form>
  );
};
