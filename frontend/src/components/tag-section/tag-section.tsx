import React from "react";
import { TagDto } from "../../api";
import { Tag } from "..";

import styles from "./styles.module.scss";

interface TagSectionProps {
  tags?: TagDto[];
}

export const TagSection = ({ tags }: TagSectionProps) => {
  return (
    <div className={styles.container}>
      {tags?.map((tag) => (
        <Tag key={tag.id} tag={tag} />
      ))}
    </div>
  );
};
