import React from "react";
import { generatePath } from "react-router-dom";

import { Link } from "../..";
import { useUserProvider } from "../../../contexts";
import { routes } from "../../../routes";

import styles from "./styles.module.scss";

export const ToolBar = () => {
  const { user } = useUserProvider();
  const pathToUser = user && generatePath(routes.user.get, { id: user?.id });

  return (
    <div className={styles.container}>
      <div>
        <Link to={routes.root}>Home</Link>
      </div>
      <div className={styles.rightSection}>
        {user ? (
          <>
            <Link to={routes.post.new}>New Post</Link>
            <div>Hello{<Link to={pathToUser}>{user.name}</Link>}</div>
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
