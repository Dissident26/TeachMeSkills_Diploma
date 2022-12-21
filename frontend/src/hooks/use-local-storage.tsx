import React, { useCallback, useEffect, useState } from "react";
import { LOCAL_STORAGE_JWT_TOKEN_KEY } from "../constants";

const EVENT_NAME = "storage";

interface LocalStorageData {
  token?: string;
}

const DEFAULT_DATA: LocalStorageData = {
  token: localStorage.getItem(LOCAL_STORAGE_JWT_TOKEN_KEY),
};

export const useLocalStorage = () => {
  const [storage, setStorage] = useState<LocalStorageData>(DEFAULT_DATA);

  const onStorageChange = useCallback(() => {
    const token = localStorage.getItem(LOCAL_STORAGE_JWT_TOKEN_KEY);
    setStorage((prev) => ({ ...prev, token }));
    console.log("storage", storage);
  }, []);

  useEffect(() => {
    window.addEventListener(EVENT_NAME, onStorageChange);
  }, []);

  const setItem = useCallback((key: string, value: string) => {
    localStorage.setItem(key, value);
    window.dispatchEvent(new Event(EVENT_NAME));
  }, []);

  const removeItem = useCallback((key: string) => {
    localStorage.removeItem(key);
    window.dispatchEvent(new Event(EVENT_NAME));
  }, []);

  return { storage, setItem, removeItem };
};
