import { QueryClient } from "react-query";

const queryCLient = new QueryClient({
  defaultOptions: {
    queries: {
      staleTime: Infinity,
    },
  },
});

export default queryCLient;
