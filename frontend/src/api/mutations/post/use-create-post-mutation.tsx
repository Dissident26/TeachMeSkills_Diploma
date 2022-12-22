import { useMutation } from "react-query";
import { createPost, PostDto } from "../..";
import { MutationKey } from "../mutation-key";

export const useCreatePostMutation = () =>
  useMutation(createPost, {
    mutationKey: MutationKey.CreatePost,
    onError: () => {},
    onSettled: () => {},
    onSuccess: () => {},
  });
