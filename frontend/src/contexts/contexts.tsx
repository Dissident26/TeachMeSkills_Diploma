import React, { ReactNode } from "react";

import { UserProvider } from "./user-context";

interface ContextsProps {
  children: ReactNode;
}

export const Contexts = ({ children }: ContextsProps) => (
  <UserProvider>{children}</UserProvider>
);
