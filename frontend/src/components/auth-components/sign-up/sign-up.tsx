import React from "react";

import { SignUpForm } from "./sign-up-form";

import styles from "./styles.module.scss";

export const SignUp = () => {
  return (
    <div className={styles.container}>
      <h2>Sign Up</h2>
      <SignUpForm />
    </div>
  );
};
