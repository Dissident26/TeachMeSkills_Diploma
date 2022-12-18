import React from "react";
import { SignInForm } from "./sign-in-form";

import styles from "./styles.module.scss";

export const SignIn = () => {
  return (
    <div className={styles.container}>
      <SignInForm />
    </div>
  );
};
