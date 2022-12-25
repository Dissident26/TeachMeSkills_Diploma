import React, { OptionHTMLAttributes } from "react";

import { AsyncSelect } from "../..";
import { getTagList } from "../../../api/requests/tag-requests";

import styles from "./styles.module.scss";

type Option = OptionHTMLAttributes<HTMLOptionElement>;

const TAGS_INPUT_NAME = "tags";

const filterOptions = (options: Option[]) => (inputValue: string) => {
  return options.filter(({ label }) =>
    label.toLowerCase().includes(inputValue.toLowerCase())
  );
};

const mapOptions = (options: any[]): Option[] => {
  return options.map((option: any) => ({
    value: option.id,
    label: option.name,
  }));
};

export const TagSelect = () => {
  const loadOptions = async (inputValue: string) => {
    const response = await getTagList();
    const values = mapOptions(response);
    const filter = filterOptions(values);

    return filter(inputValue);
  };
  <select></select>;
  return (
    <>
      <label htmlFor={TAGS_INPUT_NAME}>Tags</label>
      <AsyncSelect
        className={styles.input}
        name={TAGS_INPUT_NAME}
        isMulti
        isClearable
        placeholder={"Start typing..."}
        loadOptions={loadOptions}
        cacheOptions
      />
    </>
  );
};
