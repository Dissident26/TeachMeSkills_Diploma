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
  const { handleSubmit, register, formState } = methods;

  return (
    <FormProvider {...methods}>
      <form className={styles.form} onSubmit={handleSubmit(onSubmit)} {...rest}>
        {React.Children.map(children, (child) => {
          return child.props.name
            ? React.createElement(child.type, {
                ...{
                  ...child.props,
                  register,
                  formState,
                  key: child.props.name,
                },
              })
            : child;
        })}
      </form>
    </FormProvider>
  );
};
