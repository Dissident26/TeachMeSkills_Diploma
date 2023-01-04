import React, { ReactElement, FormHTMLAttributes } from "react";
import { useForm, FormProvider } from "react-hook-form";
import styles from "./styles.module.scss";

export interface FormProps extends FormHTMLAttributes<HTMLFormElement> {
  onSubmit: (data: any) => Promise<any>;
  defaultValues?: any;
  children?: ReactElement[];
}

export const Form = ({
  defaultValues,
  children,
  onSubmit,
  ...rest
}: FormProps) => {
  const methods = useForm({ defaultValues });
  const { handleSubmit } = methods;

  return (
    <FormProvider {...methods}>
      <form className={styles.form} onSubmit={handleSubmit(onSubmit)} {...rest}>
        {children}
      </form>
    </FormProvider>
  );
};
