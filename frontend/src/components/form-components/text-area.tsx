import React, { DetailedHTMLProps, TextareaHTMLAttributes } from "react";

import { Controller, useFormContext } from "react-hook-form";

import styles from "./styles.module.scss";

interface TextAreaProps
  extends DetailedHTMLProps<
    TextareaHTMLAttributes<HTMLTextAreaElement>,
    HTMLTextAreaElement
  > {
  label?: string;
}

export const TextArea = ({ label, name, ...rest }: TextAreaProps) => {
  const { control } = useFormContext();

  return (
    <Controller
      name={name}
      control={control}
      render={({ field }) => (
        <>
          {label && <label htmlFor={name}>{label}</label>}
          <textarea className={styles.textArea} {...rest} {...field}></textarea>
        </>
      )}
    />
  );
};
