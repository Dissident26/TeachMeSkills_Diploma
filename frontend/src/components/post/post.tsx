import React, { FunctionComponent } from "react";

import { GetPostResponse, GetUserResponse } from "../../api";
import { CommentsSection } from "../comment";
import { UserSection } from "../user";

import styles from "./styles.module.scss";

interface PostProps {
  post: GetPostResponse;
  users: Record<number, GetUserResponse>;
}

export const Post: FunctionComponent<PostProps> = ({
  post,
  users,
}: PostProps) => {
  return (
    <div className={styles.container}>
      <div key={post.id}>
        <UserSection user={users[post.userId]} />
        <p>{post.content}</p>
        <p>Created: {post.creationDate.toString()}</p>
        <CommentsSection post={post} users={users} />
      </div>
    </div>
  );
};

//user section
//tags section
//content section
//info section
