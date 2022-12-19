import React, { useEffect } from "react";
import { useGetUserByToken } from "../../api";
import { LOCAL_STORAGE_JWT_TOKEN_KEY } from "../../constants";
import { useUserProvider } from "../../contexts";
import { useLocalStorage } from "../../hooks/use-local-storage";
import { Spinner } from "../spinner";

import styles from "./styles.module.scss";
import { ToolBar } from "./tool-bar/tool-bar";

export const Header = () => {
  const { data, refetch, isLoading } = useGetUserByToken();
  const { setUser } = useUserProvider();
  const {
    storage: { token },
  } = useLocalStorage();

  useEffect(() => {
    if (token) {
      refetch();
      setUser(data);
    }
  }, [token, data]);

  if (isLoading) {
    return <Spinner />;
  }

  return (
    <div className={styles.container}>
      <ToolBar />
      <div className={styles.title}>
        <h1>J0R00m</h1>
      </div>
      <div className={styles.content}>header content</div>
    </div>
  );
};
