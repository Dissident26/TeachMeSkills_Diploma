import React from "react";
import { Link as NativeLink, LinkProps } from "react-router-dom";

import styles from "./styles.module.scss";

export const Link = (props: LinkProps) => {
  return <NativeLink className={styles.link} {...props} />;
};
