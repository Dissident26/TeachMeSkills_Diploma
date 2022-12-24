const BASE_URLS = {
  POST: "post",
  USER: "user",
  COMMENT: "comment",
  AUTH: "auth",
  TAG: "tag",
};

export const urls = {
  post: {
    get: `${BASE_URLS.POST}`,
    getList: `${BASE_URLS.POST}/list`,
    getPostListByTag: `${BASE_URLS.POST}/getPostListByTag`,
    create: `${BASE_URLS.POST}/add`,
  },
  user: {
    get: `${BASE_URLS.USER}`,
    getByIds: `${BASE_URLS.USER}/getById`,
  },
  comment: {
    getListByPostId: `${BASE_URLS.COMMENT}/getById`,
    createPostComment: `${BASE_URLS.COMMENT}/add`,
    createRepliedComment: `${BASE_URLS.COMMENT}/addReply`,
  },
  authorization: {
    signIn: `${BASE_URLS.AUTH}/singIn`,
    signUp: `${BASE_URLS.AUTH}/singUp`,
    getByToken: `${BASE_URLS.AUTH}/getByToken`,
  },
  tag: {
    get: `${BASE_URLS.TAG}`,
  },
};
