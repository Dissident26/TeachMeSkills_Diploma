import { useMutation } from "react-query";
import { updateComment } from "../..";
import { MutationKey } from "../mutation-key";

interface UseUpdateCommentMutationProps {
  onSuccess?: () => void;
  onError?: () => void;
  onSettled?: () => void;
}

export const useUpdatePostCommentMutation = ({
  onSuccess,
  onError,
  onSettled,
}: UseUpdateCommentMutationProps) =>
  useMutation(updateComment, {
    mutationKey: MutationKey.UpdateComment,
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
