import React, { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { LOCAL_STORAGE_JWT_TOKEN_KEY } from "../../../constants";
import { useLocalStorage } from "../../../hooks";
import { routes } from "../../../routes";

export const SignOut = () => {
  const { removeItem } = useLocalStorage();
  const navigate = useNavigate();

  useEffect(() => {
    removeItem(LOCAL_STORAGE_JWT_TOKEN_KEY);
    navigate(routes.root);
  }, []);

  return <></>;
};
