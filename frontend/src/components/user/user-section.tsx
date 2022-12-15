import React, { FunctionComponent } from "react";
import { useGetUser } from "../../api/queries/user/use-get-user";
import { Spinner } from "../spinner";

import styles from "./styles.module.scss";

interface UserSectionProps {
  userId?: number;
}

export const UserSection: FunctionComponent<UserSectionProps> = ({
  userId,
}: UserSectionProps) => {
  const { isLoading, data } = useGetUser(userId);

  if (isLoading) {
    return <Spinner />;
  }

  return (
    <div className={styles.container}>
      <div>{data.name}</div>
    </div>
  );
};
