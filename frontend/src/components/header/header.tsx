import React from "react";

import styles from "./styles.module.scss";

export const Header = () => {
  return (
    <div className={styles.container}>
      <div className={styles.title}>
        <h1>J0R00m</h1>
      </div>
      <div className={styles.content}>header content</div>
    </div>
  );
};
