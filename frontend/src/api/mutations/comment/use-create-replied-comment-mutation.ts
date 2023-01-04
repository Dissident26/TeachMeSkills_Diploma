import { useMutation } from "react-query";
import { createRepliedComment } from "../..";
import { MutationKey } from "../mutation-key";

interface UseCreateRepliedCommentMutationProps {
  onSuccess?: () => void;
  onError?: () => void;
  onSettled?: () => void;
}

export const useCreateRepliedCommentMutation = ({
  onSuccess,
  onError,
  onSettled,
}: UseCreateRepliedCommentMutationProps) => {
  return useMutation(createRepliedComment, {
    mutationKey: MutationKey.CreateRepliedComment,
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
};
