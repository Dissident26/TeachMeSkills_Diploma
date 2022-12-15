import React, { FunctionComponent } from "react";
import { Link, Outlet } from "react-router-dom";

import { Footer, Header } from "..";

import styles from "./styles.module.scss";

export const Root: FunctionComponent = () => {
  return (
    <>
      <div className={styles.container}>
        <Header />
        <Outlet />
        <Footer />
      </div>
    </>
  );
};
