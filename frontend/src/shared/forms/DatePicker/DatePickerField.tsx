import React from 'react';

/* eslint-disable @typescript-eslint/no-explicit-any */

type Props = {
  name: string;
  value?: string;
  onChange: (field: string, value: any, shouldValidate?: boolean) => void;
  onFocus: (field: string, isTouched?: boolean, shouldValidate?: boolean) => void;
  className: string;
  placeholder?: string;
  disabled?: boolean;
  minDate?: Date;
};

export const DatePickerField = (props: Props) => {
  return (
    <div>todo</div>
    // TODO: use ant-design instead of react-datepicker
    // TODO: use formik within booking desk
    // <DatePicker
    //   selected={(props.value && new Date(props.value)) || null}
    //   onChange={(val: Date) => {
    //     props.onChange(props.name, val ? val.toISOString() : '');
    //   }}
    //   onBlur={() => {
    //     props.onFocus(props.name, true);
    //   }}
    //   isClearable={false}
    //   wrapperClassName="w-100"
    //   className={props.className}
    //   placeholderText={props.placeholder}
    //   dateFormat="dd.MM.yyyy"
    //   disabled={props.disabled}
    //   minDate={props.minDate}
    // />
  );
};
