import React, { DetailedHTMLProps, TextareaHTMLAttributes } from "react";

import { UseFormRegister } from "react-hook-form";

import styles from "./styles.module.scss";

interface TextAreaProps
  extends DetailedHTMLProps<
    TextareaHTMLAttributes<HTMLTextAreaElement>,
    HTMLTextAreaElement
  > {
  label?: string;
  register?: UseFormRegister<any>;
}

export const TextArea = ({ name, label, register, ...rest }: TextAreaProps) => {
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
