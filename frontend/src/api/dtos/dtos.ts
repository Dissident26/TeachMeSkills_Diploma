export interface UserDto {
  id: number;
  name: string;
  avatar?: string;
  registrationDate: Date;
}
export type UserListDto = UserDto[];
export interface TagDto {
  id?: number;
  name: string;
}
export interface PostTagDto {
  tagId: number;
}
export interface PostDto {
  id: number;
  userId?: number;
  user: UserDto;
  content: string;
  creationDate: Date;
  commentsCount: number;
  tags: TagDto[];
  postTags: PostTagDto[];
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
  name: string;
  password: string;
}
