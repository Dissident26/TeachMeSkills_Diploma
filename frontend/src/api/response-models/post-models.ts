export interface GetPostResponse {
  id: number;
  userId?: number;
  content: string;
  creationDate: Date;
  commentsCount: number;
}

export type GetPostListResponse = GetPostResponse[];
