import React, { InputHTMLAttributes } from "react";

import styles from "./styles.module.scss";

type SubmitButtonProps = InputHTMLAttributes<HTMLInputElement>;

export const SubmitButton = (props: SubmitButtonProps) => {
  return (
    <input
      type="submit"
      value="Submit" //add separate file with text strings
      className={styles.submit}
      {...props}
    />
  );
};
