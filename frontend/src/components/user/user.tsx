import React from "react";
import { useParams } from "react-router-dom";

import { useGetUser } from "../../api";
import { Spinner } from "../spinner";
import { UserSection } from "../user-section";

import styles from "./styles.module.scss";

export const User = () => {
  const { id } = useParams();
  const { data, isLoading } = useGetUser(Number(id));

  if (isLoading) {
    return <Spinner />;
  }

  return (
    <div className={styles.container}>
      <UserSection user={data} avatarSize="content" />
    </div>
  );
};
