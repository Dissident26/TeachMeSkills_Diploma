import React from "react";
import { generatePath } from "react-router-dom";
import { TagDto } from "../../api";
import { routes } from "../../routes";
import { Link } from "../link";

interface TagProps {
  tag: TagDto;
}

export const Tag = ({ tag }: TagProps) => {
  const pathToTag = generatePath(routes.post.byTag, { id: tag.id });

  return <Link to={pathToTag}>{tag.name}</Link>;
};
