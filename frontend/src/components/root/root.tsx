import React, { FunctionComponent } from "react";
import { Outlet } from "react-router-dom";

import { Footer, Header, Main } from "..";
import { Contexts } from "../../contexts";

import styles from "./styles.module.scss";

export const Root: FunctionComponent = () => {
  return (
    <>
      <div className={styles.container}>
        <Contexts>
          <Header />
          <Main />
          <Footer />
        </Contexts>
      </div>
    </>
  );
};
