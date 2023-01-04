import React, { FunctionComponent } from "react";
import { generatePath } from "react-router-dom";
import { Link } from "..";
import { UserDto } from "../../api";
import { routes } from "../../routes";

import styles from "./styles.module.scss";

interface UserSectionProps {
  user?: UserDto;
  avatarSize?: string;
}

const DEFAULT_AVATAR_SIZE = "50px";

export const UserSection: FunctionComponent<UserSectionProps> = ({
  user: { id, name, avatar },
  avatarSize = DEFAULT_AVATAR_SIZE,
}: UserSectionProps) => {
  const path = generatePath(routes.user.get, {
    id,
  });

  return (
    <div className={styles.container}>
      <img src={avatar} width={avatarSize} height={avatarSize} />
      <Link to={path}>{name}</Link>
    </div>
  );
};
