import * as React from 'react';
import {ReactChild} from "react";

/* eslint-disable @typescript-eslint/no-explicit-any */

export type Option = {
  label: string;
  value: any;
};

type Props = {
  id: string;
  name: string;
  value: any;
  options: Option[];
  onChange: (field: string, value: any, shouldValidate?: boolean) => void;
  onFocus: (field: string, isTouched?: boolean, shouldValidate?: boolean) => void;
  className?: string;
  placeholder?: string;
  isSearchable?: boolean;
  disabled?: boolean;
  children?: ReactChild;
};

export const SelectField = (props: Props) => {
  return (
    <div>todo</div>
    // TODO: use ant-design instead of react-select
    // <Select
    //   value={props.options ? props.options.find((option) => option.value === props.value) : { label: '', value: null }}
    //   options={props.options}
    //   name={props.name}
    //   onChange={(option: any) => {
    //     props.onChange(props.name, option.value);
    //   }}
    //   onBlur={(option: any) => {
    //     props.onFocus(props.name, option.value);
    //   }}
    //   classNamePrefix="select"
    //   isSearchable={props.isSearchable}
    //   className={props.className}
    //   placeholder={props.placeholder}
    //   isDisabled={props.disabled}
    // />
  );
};
