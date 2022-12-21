import React from "react";
import { createBrowserRouter } from "react-router-dom";

import {
  Root,
  SignIn,
  SignUp,
  SignOut,
  User,
  AllPosts,
  SinglePost,
} from "../components";
import { routes } from "./routes";

export const router = createBrowserRouter([
  {
    path: routes.root,
    element: <Root />,
    children: [
      {
        path: routes.root,
        element: <AllPosts />,
      },
      {
        path: routes.post.get,
        element: <SinglePost />,
      },
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
      {
        path: routes.user.get,
        element: <User />,
      },
    ],
  },
]);
