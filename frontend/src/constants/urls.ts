const BASE_URLS = {
  POST: "Post",
  USER: "User",
};

export const urls = {
  Post: {
    Get: `${BASE_URLS.POST}`,
    GetList: `${BASE_URLS.POST}/List`,
  },
  User: {
    Get: `${BASE_URLS.USER}`,
  },
};
