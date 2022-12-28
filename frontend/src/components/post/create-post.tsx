import React, { useCallback } from "react";
import { Form, SubmitButton, TextArea } from "..";
import { PostTagDto, TagDto, useCreatePostMutation } from "../../api";
import { Spinner } from "../spinner";
import { TagSelect } from "../tag/tag-select/tag-select";

import styles from "./styles.module.scss";

interface TagOption {
  label: string;
  value: number;
  __isNew__?: boolean;
}
interface SubmitType {
  content: string;
  tags: TagOption[];
}

const CONTENT_INPUT_NAME = "content";

export const CreatePost = () => {
  const { mutateAsync, isLoading } = useCreatePostMutation();
  const onSubmit = useCallback(
    async (data: SubmitType) => {
      const tags = [] as TagDto[];
      const postTags = [] as PostTagDto[];

      data.tags.forEach((tag) => {
        if (tag.__isNew__) {
          tags.push({ name: tag.label });
        } else {
          postTags.push({ tagId: tag.value });
        }
      });

      await mutateAsync({ ...data, tags, postTags });
    },
    [mutateAsync]
  );

  if (isLoading) {
    return <Spinner />;
  }

  return (
    <div className={styles.formContainer}>
      <Form onSubmit={onSubmit}>
        <TagSelect />
        <TextArea
          className={styles.textArea}
          name={CONTENT_INPUT_NAME}
          required
          label={"Content"}
        />
        <SubmitButton />
      </Form>
    </div>
  );
};
