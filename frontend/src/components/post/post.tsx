import React, { FunctionComponent } from "react";

import { PostDto } from "../../api";
import { CommentsSection } from "../comment";
import { UserSection } from "../user";

import styles from "./styles.module.scss";

interface PostProps {
  post: PostDto;
}

export const Post: FunctionComponent<PostProps> = ({ post }: PostProps) => {
  return (
    <div className={styles.container}>
      <div key={post.id}>
        <UserSection user={post.user} />
        <p>{post.content}</p>
        <CommentsSection post={post} />
      </div>
    </div>
  );
};

//user section
//tags section
//content section
//info section
