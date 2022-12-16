export interface GetCommentResponse {
  id: number;
  postId: number;
  userId?: number;
  repliedCommentId?: number;
  content: string;
  creationDate: Date;
}

export type GetCommentListResponse = GetCommentResponse[];
