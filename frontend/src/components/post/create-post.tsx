import React from "react";
import { Form, Input, SubmitButton, TextArea } from "..";
import { useCreatePostMutation } from "../../api";
import { Spinner } from "../spinner";

import styles from "./styles.module.scss";

const TAGS_INPUT_NAME = "tags";
const CONTENT_INPUT_NAME = "content";

export const CreatePost = () => {
  const { mutateAsync, isLoading } = useCreatePostMutation();

  if (isLoading) {
    return <Spinner />;
  }

  return (
    <div className={styles.formContainer}>
      <Form onSubmit={mutateAsync}>
        <Input
          className={styles.tagsInput}
          name={TAGS_INPUT_NAME}
          required
          label={"Tags"}
        />
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
