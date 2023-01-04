import React from "react";
import { RouteObject } from "react-router-dom";

import { SignIn, SignUp, SignOut } from "../components";
import { routes } from "./routes";

export const authRoutes: RouteObject[] = [
  {
    path: routes.auth.signIn,
    element: <SignIn />,
  },
  {
    path: routes.auth.signUp,
    element: <SignUp />,
  },
  {
    path: routes.auth.signOut,
    element: <SignOut />,
  },
];
