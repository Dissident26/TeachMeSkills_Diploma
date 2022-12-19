const BASE_URLS = {
  POST: "Post",
  USER: "User",
  COMMENT: "Comment",
  AUTH: "Auth",
};

export const urls = {
  post: {
    get: `${BASE_URLS.POST}`,
    getList: `${BASE_URLS.POST}/List`,
  },
  user: {
    get: `${BASE_URLS.USER}`,
    getByIds: `${BASE_URLS.USER}/GetById`,
  },
  comment: {
    getListByPostId: `${BASE_URLS.COMMENT}/GetById`,
  },
  authorization: {
    signIn: `${BASE_URLS.AUTH}/SingIn`,
    signUp: `${BASE_URLS.AUTH}/SingUp`,
    getByToken: `${BASE_URLS.AUTH}/GetByToken`,
  },
};
