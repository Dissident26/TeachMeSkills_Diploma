import React from "react";

import { Link } from "../..";
import { routes } from "../../../routes";

import styles from "./styles.module.scss";
interface ToolBarProps {
  isUserAuthorized?: boolean;
}

export const ToolBar = ({ isUserAuthorized = false }: ToolBarProps) => {
  return (
    <div className={styles.container}>
      <div>
        <Link to={routes.root}>Home</Link>
      </div>
      {isUserAuthorized ? (
        <div>Hello authorized user</div>
      ) : (
        <div className={styles.rightSection}>
          <Link to={routes.auth.signIn}>Sign in</Link>
          <Link to={routes.auth.signUp}>Sign up</Link>
        </div>
      )}
    </div>
  );
};
