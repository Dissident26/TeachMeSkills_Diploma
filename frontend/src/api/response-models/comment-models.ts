export interface GetCommentResponse {
  id: number;
  postId: number;
  userId?: number;
  repliedComments?: null | GetCommentResponse[];
  content: string;
  creationDate: Date;
}

export type GetCommentListResponse = GetCommentResponse[];
