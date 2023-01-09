import React, { DetailedHTMLProps } from "react";

import styles from "./styles.module.scss";

interface ButtonProps
  extends DetailedHTMLProps<
    React.ButtonHTMLAttributes<HTMLButtonElement>,
    HTMLButtonElement
  > {
  onClick?: () => void;
  value: string;
  className?: string;
}

export const Button = ({ value, onClick, className }: ButtonProps) => (
  <button className={className || styles.button} onClick={onClick}>
    {value}
  </button>
);
