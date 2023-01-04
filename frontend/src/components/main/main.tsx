import React, { FunctionComponent } from "react";
import { Outlet } from "react-router-dom";
import { Post, Spinner } from "..";
import { PostDto, useGetPostsList } from "../../api";

import styles from "./styles.module.scss";

export const Main: FunctionComponent = () => {
  return (
    <div className={styles.container}>
      <Outlet />
    </div>
  );
};
