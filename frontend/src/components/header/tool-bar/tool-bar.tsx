import React from "react";
import { Link } from "../..";

import styles from "./styles.module.scss";

interface ToolBarProps {
  isUserAuthorized?: boolean;
}

export const ToolBar = ({ isUserAuthorized = false }: ToolBarProps) => {
  return (
    <div className={styles.container}>
      <div>
        <Link to="/">Home</Link>
      </div>
      {isUserAuthorized ? (
        <div>Hello authorized user</div>
      ) : (
        <div className={styles.rightSection}>
          <Link to="/sign-in">Sign in</Link>
          <Link to="#">SIgn up</Link>
        </div>
      )}
    </div>
  );
};
