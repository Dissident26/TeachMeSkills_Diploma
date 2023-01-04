import { useMutation } from "react-query";
import { generatePath, useNavigate } from "react-router-dom";

import { createPost } from "../..";
import { routes } from "../../../routes";
import { MutationKey } from "../mutation-key";

export const useCreatePostMutation = () => {
  const navigate = useNavigate();
  return useMutation(createPost, {
    mutationKey: MutationKey.CreatePost,
    onSuccess: ({ id }) => {
      const pathToPost = generatePath(routes.post.get, {
        id,
      });

      navigate(pathToPost);
    },
  });
};
