import React from "react";
import { createBrowserRouter } from "react-router-dom";

import { Root, User, AllPosts, SinglePost, PostListByTag } from "../components";
import { routes } from "./routes";
import { authRoutes } from ".";

export const router = createBrowserRouter([
  {
    path: routes.root,
    element: <Root />,
    children: [
      ...authRoutes,
      {
        path: routes.root,
        element: <AllPosts />,
      },
      {
        path: routes.post.get,
        element: <SinglePost />,
      },
      {
        path: routes.user.get,
        element: <User />,
      },
      {
        path: routes.post.byTag,
        element: <PostListByTag />,
      },
    ],
  },
]);
