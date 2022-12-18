import React from "react";
import { createBrowserRouter } from "react-router-dom";

import { Main, Root, SignIn } from "../components";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <Root />,
    children: [
      {
        path: "main",
        element: <Main />,
      },
      {
        path: "sign-in",
        element: <SignIn />,
      },
    ],
  },
]);
