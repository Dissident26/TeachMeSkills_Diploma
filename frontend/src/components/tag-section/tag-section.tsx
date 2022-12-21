import React from "react";
import { TagDto } from "../../api";
import { urls } from "../../constants";
import { Link } from "../link";

import styles from "./styles.module.scss";

interface TagSectionProps {
  tags?: TagDto[];
}

export const TagSection = ({ tags }: TagSectionProps) => {
  return (
    <div className={styles.container}>
      {tags?.map(({ id, name }) => (
        <Link key={id} to={`${urls.tag.get}/${id}`}>
          {name}
        </Link>
      ))}
    </div>
  );
};
