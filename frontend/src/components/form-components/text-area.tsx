import React, { DetailedHTMLProps, TextareaHTMLAttributes } from "react";

import { FormState, UseFormRegister } from "react-hook-form";

import styles from "./styles.module.scss";

interface TextAreaProps
  extends DetailedHTMLProps<
    TextareaHTMLAttributes<HTMLTextAreaElement>,
    HTMLTextAreaElement
  > {
  label?: string;
  register?: UseFormRegister<any>;
  formState?: FormState<any>;
}

export const TextArea = ({
  name,
  label,
  register,
  formState,
  ...rest
}: TextAreaProps) => {
  return (
    //formstate торчит в дом
    <>
      {label && <label htmlFor={name}>{label}</label>}
      <textarea
        className={styles.textArea}
        {...rest}
        {...register?.(name, { required: "* This field is required" })}
      ></textarea>
    </>
  );
};
