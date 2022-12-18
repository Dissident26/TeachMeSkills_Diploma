export interface UserDto {
  id: number;
  name: string;
  registrationDate: Date;
}
export type UserListDto = UserDto[];

export interface PostDto {
  id: number;
  userId?: number;
  user: UserDto;
  content: string;
  creationDate: Date;
  commentsCount: number;
}
export type PostListDto = PostDto[];

export interface CommentDto {
  id: number;
  postId: number;
  userId?: number;
  user: UserDto;
  repliedComments?: null | CommentDto[];
  content: string;
  creationDate: Date;
}
export type CommentListDto = CommentDto[];

export interface UserAuthRequestDto {
  email: string;
  password: string;
}
