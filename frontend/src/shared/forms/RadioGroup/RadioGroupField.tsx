import * as React from 'react';
import { Radio } from 'antd';
import { ReactChild } from 'react';
import classNames from 'classnames';
import './RadioGroupField.css';

type Props = {
  name: string;
  value: string;
  onChange: (field: string, value: any, shouldValidate?: boolean) => void;
  id: string;
  children?: ReactChild;
  items: () => ReactChild;
  className?: string;
  disabled?: boolean;
};

export const RadioGroupField: React.FC<Props> = ({ name, value, onChange, id, className, disabled, children, items }: Props) => {
  return (
    <>
      {children && (
        <label className={classNames('InputField__label', 'RadioGroupField__label')} htmlFor={id}>
          {children}
        </label>
      )}
      <Radio.Group
        id={id}
        value={value}
        name={name}
        onChange={(e) => onChange(name, e.target.value)}
        className={classNames('RadioGroupField', className)}
        disabled={disabled}
      >
        {items()}
      </Radio.Group>
    </>
  );
};
