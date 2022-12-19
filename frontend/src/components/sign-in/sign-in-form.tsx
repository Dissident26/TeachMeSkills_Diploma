import React, { useCallback } from "react";

import { Form, Input, SubmitButton } from "../";
import { signIn, UserAuthRequestDto } from "../../api";
import { LOCAL_STORAGE_JWT_TOKEN_KEY } from "../../constants";

import styles from "./styles.module.scss";

const LOGIN_INPUT_NAME = "Name";
const PASSWORD_INPUT_NAME = "Password";

export const SignInForm = () => {
  const onSubmit = useCallback(async (data: UserAuthRequestDto) => {
    const token = await signIn(data);
    localStorage.setItem(LOCAL_STORAGE_JWT_TOKEN_KEY, "Bearer " + token);
  }, []);

  return (
    <div className={styles.formContainer}>
      <Form onSubmit={onSubmit}>
        <Input name={LOGIN_INPUT_NAME} required label={"name"} />
        <Input
          type="password"
          name={PASSWORD_INPUT_NAME}
          required
          label={"password"}
        />
        <SubmitButton />
      </Form>
    </div>
  );
};
