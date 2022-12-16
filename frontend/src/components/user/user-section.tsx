import React, { FunctionComponent } from "react";
import { UserDto } from "../../api";

import styles from "./styles.module.scss";

interface UserSectionProps {
  user?: UserDto;
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
