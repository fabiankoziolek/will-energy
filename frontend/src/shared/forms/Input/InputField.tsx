import * as React from 'react';
import { Input } from 'antd';
import { ReactChild } from 'react';
import classNames from 'classnames';
import './InputField.css';

type Props = {
  name: string;
  value: string;
  type: string;
  onChange: (field: string, value: any, shouldValidate?: boolean) => void;
  onFocus: (field: string, isTouched?: boolean, shouldValidate?: boolean) => void;
  id: string;
  children?: ReactChild;
  className?: string;
  placeholder?: string;
  disabled?: boolean;
  error?: string;
};

export const InputField: React.FC<Props> = ({
  name,
  value,
  type,
  onChange,
  onFocus,
  id,
  className,
  placeholder,
  disabled,
  children,
  error,
}: Props) => {
  return (
    <>
      {!!children && (
        <label className="InputField__label" htmlFor={id}>
          {children}
        </label>
      )}
      <Input
        id={id}
        value={value}
        type={type}
        name={name}
        onChange={(e) => onChange(name, e.target.value)}
        onFocus={() => onFocus(name, true)}
        className={classNames('InputField', { 'InputField--error': !!error }, className)}
        placeholder={placeholder}
        disabled={disabled}
      />
      {!!error && (
        <div role="alert" className="InputField__error">
          {error}
        </div>
      )}
    </>
  );
};
