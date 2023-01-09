import React, { useMemo } from "react";
import { generatePath, useNavigate } from "react-router-dom";
import { Button } from "../..";
import { routes } from "../../../routes";

import styles from "./styles.module.scss";
import { usePaginationRange } from "./use-pagination-range";

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

  const paginationRange = usePaginationRange({
    totalPageCount: pagesCount,
    currentPage: currentPage,
  });

  const navButtons = useMemo(() => {
    const pagesArray = paginationRange?.reverse();

    return pagesArray?.map((i: number) => {
      if (!i) {
        return (
          <span key={i} className={styles.dots}>
            ...
          </span>
        );
      }

      return (
        <Button
          key={i}
          className={i === currentPage ? styles.selected : undefined}
          onClick={() => navigateToPath(i)}
          value={i.toString()}
        />
      );
    });
  }, [currentPage, pagesCount]);

  return (
    <div className={styles.container}>
      {currentPage > 1 && (
        <Button
          onClick={() => navigateToPath(currentPage - 1)}
          value="previous"
        />
      )}
      {navButtons}
      {currentPage < pagesCount && (
        <Button onClick={() => navigateToPath(currentPage + 1)} value="next" />
      )}
    </div>
  );
};
