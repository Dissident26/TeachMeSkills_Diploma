const BASE_URLS = {
  POST: "Post",
  USER: "User",
  COMMENT: "Comment",
  AUTH: "Auth",
};

export const urls = {
  Post: {
    Get: `${BASE_URLS.POST}`,
    GetList: `${BASE_URLS.POST}/List`,
  },
  User: {
    Get: `${BASE_URLS.USER}`,
    GetByIds: `${BASE_URLS.USER}/GetById`,
  },
  Comment: {
    GetListByPostId: `${BASE_URLS.COMMENT}/GetById`,
  },
  Authorization: {
    SignIn: `${BASE_URLS.AUTH}/SingIn`,
  },
};
