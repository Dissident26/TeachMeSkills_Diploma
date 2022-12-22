import React, { InputHTMLAttributes } from "react";
import { UseFormRegister } from "react-hook-form";

import styles from "./styles.module.scss";

interface SubmitButtonProps extends InputHTMLAttributes<HTMLInputElement> {
  register?: UseFormRegister<any>;
}

export const SubmitButton = ({
  register,
  name,
  ...rest
}: SubmitButtonProps) => {
  return (
    <input
      type="submit"
      value="Submit" //add separate file with text strings
      className={styles.submit}
      {...rest}
      {...register?.(name)}
    />
  );
};
