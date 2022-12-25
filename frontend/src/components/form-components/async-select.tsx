import React from "react";
import { default as NativeAsyncSelect, AsyncProps } from "react-select/async";

import { Controller, useFormContext } from "react-hook-form";

export const AsyncSelect = (props: AsyncProps<any, any, any>) => {
  const { control } = useFormContext();

  return (
    <Controller
      name={props.name}
      control={control}
      render={({ field }) => <NativeAsyncSelect {...field} {...props} />}
    />
  );
};
