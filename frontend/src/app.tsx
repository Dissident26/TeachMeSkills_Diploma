import React from "react";
import { QueryClientProvider } from "react-query";
import { RouterProvider } from "react-router-dom";

import queryCLient from "./api/queries/query-client";

import { router } from "./routes";

import "./index.scss";

const App = () => {
  return (
    <QueryClientProvider client={queryCLient}>
      <RouterProvider router={router} />
    </QueryClientProvider>
  );
};

export default App;
