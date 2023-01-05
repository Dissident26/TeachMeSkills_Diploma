import React from "react";
import { createBrowserRouter } from "react-router-dom";

import {
  Root,
  User,
  AllPosts,
  SinglePost,
  PostListByTag,
  CreatePost,
} from "../components";
import { routes } from "./routes";
import { authRoutes } from ".";
import { PostWithPagination } from "../components/post/post-with-pagination";

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
        path: routes.post.getByPage,
        element: <PostWithPagination />,
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
      {
        path: routes.post.new,
        element: <CreatePost />,
      },
    ],
  },
]);
