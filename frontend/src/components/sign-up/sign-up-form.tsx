import React, { useCallback } from "react";
import { useNavigate } from "react-router-dom";

import { Form, Input, SubmitButton } from "../";
import { signUp, UserAuthRequestDto } from "../../api";
import { routes } from "../../routes";

import styles from "./styles.module.scss";

interface UserSignUpData extends UserAuthRequestDto {
  confirmPassword: string;
}

const LOGIN_INPUT_NAME = "Name";
const PASSWORD_INPUT_NAME = "Password";

export const SignUpForm = () => {
  const navigate = useNavigate();
  const onSubmit = useCallback(async (data: UserAuthRequestDto) => {
    await signUp(data);
    navigate(routes.auth.signIn);
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
