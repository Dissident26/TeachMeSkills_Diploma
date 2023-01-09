import React, { FunctionComponent } from "react";

import { PostDto } from "../../api";
import { CommentsSection } from "../comment";
import { TagSection } from "../tag-section";
import { UserSection } from "../user-section";

import styles from "./styles.module.scss";

interface PostProps {
  post: PostDto;
}

export const Post: FunctionComponent<PostProps> = ({ post }: PostProps) => {
  return (
    <div className={styles.container}>
      <UserSection user={post.user} />
      <TagSection tags={post?.tags} />
      <p>{post.content}</p>
      <CommentsSection post={post} />
    </div>
  );
};
