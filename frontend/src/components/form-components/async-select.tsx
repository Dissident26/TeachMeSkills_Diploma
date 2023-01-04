import React from "react";
import {
  default as NativeAsyncSelect,
  AsyncCreatableProps,
} from "react-select/async-creatable";

import { Controller, useFormContext } from "react-hook-form";

export const AsyncSelect = (props: AsyncCreatableProps<any, any, any>) => {
  const { control } = useFormContext();

  return (
    <Controller
      name={props.name}
      control={control}
      render={({ field }) => <NativeAsyncSelect {...field} {...props} />}
    />
  );
};
