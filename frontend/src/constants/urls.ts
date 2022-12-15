const BASE_URLS = {
  POST: "Post",
};

export const urls = {
  Post: {
    Get: `${BASE_URLS.POST}/{id}`,
    GetList: `${BASE_URLS.POST}/List`,
  },
};
