export const routes = {
  root: "/",
  auth: {
    signIn: "/sign-in",
    signUp: "/sign-up",
    signOut: "/sign-out",
  },
  user: {
    get: "/user/:id",
  },
  post: {
    get: "/post/:id",
    byTag: "/post/tag/:id",
    new: "post/new",
  },
};
