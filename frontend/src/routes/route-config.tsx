import React from "react";
import { createBrowserRouter } from "react-router-dom";

import { Main, Root } from "../components";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <Root />,
    children: [
      {
        path: "main",
        element: <Main />,
      },
    ],
  },
]);
