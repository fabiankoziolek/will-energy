import * as React from 'react';
import { ReactChild } from 'react';
import { Select } from 'antd';
import classNames from 'classnames';
import './SelectField.css';

/* eslint-disable @typescript-eslint/no-explicit-any */

export type SelectOption = {
  label: string;
  value: any;
};

type Props = {
  name: string;
  value: string;
  onChange: (field: string, value: any, shouldValidate?: boolean) => void;
  onFocus: (field: string, isTouched?: boolean, shouldValidate?: boolean) => void;
  id: string;
  children?: ReactChild;
  className?: string;
  placeholder?: string;
  disabled?: boolean;
  error?: string;
  options: SelectOption[];
  isSearchable?: boolean;
};

export const SelectField: React.FC<Props> = ({
  name,
  value,
  onChange,
  onFocus,
  id,
  className,
  placeholder,
  disabled,
  children,
  error,
  options,
  isSearchable,
}: Props) => {
  return (
    <>
      {!!children && (
        <label className="SelectField__label" htmlFor={id}>
          {children}
        </label>
      )}
      <Select
        id={id}
        value={value}
        onChange={(e) => onChange(name, e)}
        onFocus={() => onFocus(name, true)}
        className={classNames('SelectField', { 'SelectField--error': !!error }, className)}
        placeholder={placeholder}
        showSearch={isSearchable}
        disabled={disabled}
      >
        {options.map((x) => (
          <Select.Option key={x.value} value={x.value}>
            {x.label}
          </Select.Option>
        ))}
      </Select>
      {!!error && (
        <div role="alert" className="SelectField__error">
          {error}
        </div>
      )}
    </>
  );
};
