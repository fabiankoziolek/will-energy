import * as React from 'react';
import { ReactChild } from 'react';
import { DatePicker } from 'antd';
import classNames from 'classnames';
import './DatePickerField.css';
import moment from 'moment';
import 'moment/locale/pl';
import locale from 'antd/es/date-picker/locale/pl_PL';

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
};

export const DatePickerField: React.FC<Props> = ({
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
}: Props) => {
  return (
    <>
      {!!children && (
        <label className="DatePickerField__label" htmlFor={id}>
          {children}
        </label>
      )}
      <DatePicker
        picker="month"
        locale={locale}
        id={id}
        value={moment(value || new Date())}
        onChange={(e) => onChange(name, e)}
        onFocus={() => onFocus(name, true)}
        className={classNames('DatePickerField', { 'DatePickerField--error': !!error }, className)}
        placeholder={placeholder}
        disabled={disabled}
      />
      {!!error && (
        <div role="alert" className="DatePickerField__error">
          {error}
        </div>
      )}
    </>
  );
};
