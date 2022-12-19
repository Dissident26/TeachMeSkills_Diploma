import React, { FunctionComponent } from "react";
import { Outlet } from "react-router-dom";

import { Footer, Header } from "..";
import { Contexts } from "../../contexts";

import styles from "./styles.module.scss";

export const Root: FunctionComponent = () => {
  return (
    <>
      <div className={styles.container}>
        <Contexts>
          <Header />
          <Outlet />
          <Footer />
        </Contexts>
      </div>
    </>
  );
};
