import React from "react";
import { Form, Input, SubmitButton, TextArea } from "..";
import { useCreatePostMutation } from "../../api";
import { Spinner } from "../spinner";
import { TagSelect } from "../tag/tag-select/tag-select";

import styles from "./styles.module.scss";

const CONTENT_INPUT_NAME = "content";

export const CreatePost = () => {
  const { mutateAsync, isLoading } = useCreatePostMutation();
  const submit = async (data: any) => {
    console.log("submit", data);
  };

  if (isLoading) {
    return <Spinner />;
  }

  return (
    <div className={styles.formContainer}>
      <Form onSubmit={submit}>
        {/* <Input
          className={styles.tagsInput}
          name={TAGS_INPUT_NAME}
          required
          label={"Tags"}
        /> */}
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
