import React from "react";
import { createBrowserRouter } from "react-router-dom";

import { Main, Root, SignIn, SignUp } from "../components";
import { routes } from "./routes";

export const router = createBrowserRouter([
  {
    path: routes.root,
    element: <Root />,
    children: [
      {
        path: routes.root,
        element: <Main />,
      },
      {
        path: routes.auth.signIn,
        element: <SignIn />,
      },
      {
        path: routes.auth.signUp,
        element: <SignUp />,
      },
    ],
  },
]);
