import React, { OptionHTMLAttributes } from "react";
import debounce from "lodash/debounce";

import { AsyncSelect } from "../..";
import { getSuggestedTags } from "../../../api";

import styles from "./styles.module.scss";

type Option = OptionHTMLAttributes<HTMLOptionElement>;

const TAGS_INPUT_NAME = "tags";
const DEBOUNCE_VALUE = 1000;

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
    const response = await getSuggestedTags(inputValue);
    const values = mapOptions(response);
    const filter = filterOptions(values);

    return filter(inputValue);
  };

  const debouncedLoadOptions = debounce(
    (inputValue, callback) => {
      loadOptions(inputValue).then((data) => {
        callback(data);
      });
    },
    DEBOUNCE_VALUE,
    {
      trailing: true,
    }
  );

  return (
    <>
      <label htmlFor={TAGS_INPUT_NAME}>Tags</label>
      <AsyncSelect
        className={styles.input}
        name={TAGS_INPUT_NAME}
        isMulti
        isClearable
        placeholder={"Start typing..."}
        loadOptions={debouncedLoadOptions}
        cacheOptions
      />
    </>
  );
};
