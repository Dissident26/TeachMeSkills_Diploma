import React, { FunctionComponent } from "react";
import { GetUserResponse } from "../../api";

import styles from "./styles.module.scss";

interface UserSectionProps {
  user?: GetUserResponse;
}

export const UserSection: FunctionComponent<UserSectionProps> = ({
  user,
}: UserSectionProps) => {
  return (
    <div className={styles.container}>
      <div>{user?.name}</div>
    </div>
  );
};
