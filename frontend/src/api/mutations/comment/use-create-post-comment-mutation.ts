import { useMutation } from "react-query";
import { createPostComment } from "../..";
import { MutationKey } from "../mutation-key";

interface UseCreatePostCommentMutationProps {
  onSuccess?: () => void;
  onError?: () => void;
  onSettled?: () => void;
}

export const useCreatePostCommentMutation = ({
  onSuccess,
  onError,
  onSettled,
}: UseCreatePostCommentMutationProps) =>
  useMutation(createPostComment, {
    mutationKey: MutationKey.CreatePostComment,
    onError: () => {
      onError && onError();
    },
    onSettled: () => {
      onSettled && onSettled();
    },
    onSuccess: () => {
      onSuccess && onSuccess();
    },
  });
