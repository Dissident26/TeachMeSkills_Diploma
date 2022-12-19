import React from "react";

import { Link } from "../..";
import { useUserProvider } from "../../../contexts";
import { routes } from "../../../routes";

import styles from "./styles.module.scss";

export const ToolBar = () => {
  const { user } = useUserProvider();

  return (
    <div className={styles.container}>
      <div>
        <Link to={routes.root}>Home</Link>
      </div>
      <div className={styles.rightSection}>
        {user ? (
          <>
            <div>{`Hello ${user.name}`}</div>
            <Link to={routes.auth.signOut}>Sign out</Link>
          </>
        ) : (
          <>
            <Link to={routes.auth.signIn}>Sign in</Link>
            <Link to={routes.auth.signUp}>Sign up</Link>
          </>
        )}
      </div>
    </div>
  );
};
