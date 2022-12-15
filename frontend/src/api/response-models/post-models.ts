export interface GetPostResponse {
  id: number;
  userId?: number;
  content: string;
  creationDate: Date;
}

export type GetPostListResponse = GetPostResponse[];
