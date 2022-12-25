import React, { InputHTMLAttributes } from "react";
import { useFormContext, Controller } from "react-hook-form";

import styles from "./styles.module.scss";

export interface InputProps extends InputHTMLAttributes<HTMLInputElement> {
  label?: string;
}

export const Input = ({ label, name, ...rest }: InputProps) => {
  const {
    control,
    formState: { errors },
  } = useFormContext();

  return (
    <Controller
      name={name}
      control={control}
      render={({ field }) => (
        <>
          {label && <label htmlFor={name}>{label}</label>}
          <input {...rest} {...field} />
          {errors[name] && (
            <span
              className={styles.inputError}
            >{`${errors[name].message}`}</span>
          )}
        </>
      )}
    />
  );
};
