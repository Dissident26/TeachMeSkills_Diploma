import React, { useCallback } from "react";

import { Form, Input, SubmitButton } from "../";
import { authUser, UserAuthRequestDto } from "../../api";
import { LOCAL_STORAGE_JWT_TOKEN_KEY } from "../../constants";

import styles from "./styles.module.scss";

const EMAIL_INPUT_NAME = "Email";
const PASSWORD_INPUT_NAME = "Password";

export const SignInForm = () => {
  const onSubmit = useCallback(async (data: UserAuthRequestDto) => {
    const token = await authUser(data);
    await localStorage.setItem(LOCAL_STORAGE_JWT_TOKEN_KEY, "Bearer " + token);
  }, []);

  return (
    <div className={styles.formContainer}>
      <Form onSubmit={onSubmit}>
        <Input name={EMAIL_INPUT_NAME} required label={"email"} />
        <Input name={PASSWORD_INPUT_NAME} required label={"password"} />
        <SubmitButton />
      </Form>
    </div>
  );
};
