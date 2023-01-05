import React, { useMemo } from "react";
import { generatePath, useNavigate } from "react-router-dom";
import { routes } from "../../../routes";

import styles from "./styles.module.scss";

export const usePostPagesNavButtons = (
  pagesCount: number,
  currentPage = pagesCount
) => {
  const navigate = useNavigate();
  const navigateToPath = (page: number) => {
    navigate(
      generatePath(routes.post.getByPage, {
        page,
      })
    );
  };

  const navButtons = useMemo(() => {
    const pagesArray = Array.from(
      { length: pagesCount },
      (_, i) => i + 1
    ).reverse();

    return pagesArray.map((i) => (
      <button
        key={i}
        className={i === currentPage ? styles.selected : undefined}
        onClick={() => navigateToPath(i)}
      >
        {i}
      </button>
    ));
  }, [currentPage, pagesCount]);

  return (
    <div>
      {currentPage > 1 && (
        <button onClick={() => navigateToPath(currentPage - 1)}>next</button>
      )}
      {navButtons}
      {currentPage < pagesCount && (
        <button onClick={() => navigateToPath(currentPage + 1)}>
          previous
        </button>
      )}
    </div>
  );
};
