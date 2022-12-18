import React, { InputHTMLAttributes } from "react";
import { UseFormRegister, FormState } from "react-hook-form";

import styles from "./styles.module.scss";

export interface InputProps extends InputHTMLAttributes<HTMLInputElement> {
  label?: string;
  register?: UseFormRegister<any>;
  formState?: FormState<any>;
  errorMessage?: string;
}

export const Input = ({
  register,
  formState: { errors },
  errorMessage,
  required = false,
  name,
  label,
  ...rest
}: InputProps) => {
  return (
    <>
      {label && <label htmlFor={name}>{label}</label>}
      <input
        className={styles.input}
        {...rest}
        {...register?.(name, { required: "* This field is required" })}
      />
      {errors[name] && (
        <span className={styles.inputError}>{`${errors[name].message}`}</span>
      )}
    </>
  );
};
