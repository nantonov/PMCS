export type RequiredValidator = (value: string) => string | undefined;

export const required : RequiredValidator = (value) => {
  if (value) return undefined;
  return "Field is required";
};

