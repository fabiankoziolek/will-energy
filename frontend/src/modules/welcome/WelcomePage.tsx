import * as React from 'react';
import { Field, Form, Formik, FormikProps } from 'formik';
import classNames from 'classnames';
import * as Yup from 'yup';
import { isEmpty } from 'lodash';
import { Option, SelectField } from '../../shared/forms/Select/SelectField';
import { DatePickerField } from '../../shared/forms/DatePicker/DatePickerField';
import { GoogleAddressIncome, GoogleSuggest } from '../../shared/forms/GoogleSuggest/GoogleSuggest';
import './WelcomePage.css';

const initialFormValues = {
  email: '',
  password: '',
  address: '',
  select: '',
  date: '',
  date2: '',
  check: false,
  check2: true,
  radio: '',
};

type FormValues = typeof initialFormValues;

const FormSchema = Yup.object().shape<FormValues>({
  email: Yup.string().email('Invalid email').required('Required'),
  password: Yup.string().required('Required'),
  address: Yup.string().required('Required'),
  select: Yup.string().required('Required'),
  date: Yup.string().required('Required'),
  date2: Yup.string().required('Required'),
  check: Yup.boolean().required('Required'),
  check2: Yup.boolean().required('Required'),
  radio: Yup.string().required('Required'),
});

const sampleOptions: Option[] = [
  {
    label: 'Undefined',
    value: 'Undefined',
  },
  {
    label: 'Other',
    value: 'Other',
  },
];

export const WelcomePage = () => {
  const onSubmit = (form: FormValues) => {
    console.log(form);
  };

  return (
    <Formik
      validationSchema={FormSchema}
      initialValues={initialFormValues}
      onSubmit={onSubmit}
      render={({ errors, touched, values, setFieldValue, setFieldTouched }: FormikProps<FormValues>) => (
        <Form className="WelcomePage">
          <div className="FormGroup">
            <Field
              type="email"
              name="email"
              id="email"
              className={classNames('FormControl FormControl--large', {
                'FormControl--invalid': touched.email && errors.email,
              })}
            />
            <div className="FormInvalidFeedback">{errors.email}</div>
          </div>
          Address input:
          <GoogleSuggest onSelect={(value: GoogleAddressIncome) => console.log(value)} />
          <div className="FormGroup">
            <label htmlFor="password">Etternavn</label>
            <Field
              type="password"
              name="password"
              id="password"
              className={classNames('FormControl', {
                'FormControl--invalid': touched.password && errors.password,
              })}
            />
          </div>
          <div className="FormGroup">
            <label htmlFor="address">Adresse</label>
            <Field
              type="text"
              name="address"
              id="address"
              className={classNames('FormControl', {
                'FormControl--invalid': touched.address && errors.address,
              })}
              disabled={true}
              placeholder="placeholder text"
            />
          </div>
          <div className="FormGroup">
            <label>Build in checkbox and radio</label>
            <div className="FormCheck">
              <Field
                type="checkbox"
                name="check"
                id="check1"
                className={classNames('FormCheck__input', {
                  'FormControl--invalid': touched.check && errors.check,
                })}
              />
              <label className="FormCheck__label" htmlFor="check1">
                Check this custom checkbox
              </label>
            </div>
            <div className="FormCheck">
              <Field
                type="checkbox"
                name="check2"
                id="check2"
                className={classNames('FormCheck__input', {
                  'FormControl--invalid': touched.check2 && errors.check2,
                })}
                disabled={true}
              />
              <label className="FormCheck__label" htmlFor="check2">
                Do not click this custom disabled checkbox
              </label>
            </div>
            <div className="FormGroup">
              <label>Build in Select</label>
              <select className="FormControl" defaultValue="" name="" id="">
                <option disabled value="">
                  Select...
                </option>
                {sampleOptions.map((option) => (
                  <option key={option.value} value={option.value}>
                    {option.label}
                  </option>
                ))}
              </select>
            </div>
            <div className="FormGroup">
              <label>Custom Select</label>
              <select className="FormCustomSelect" defaultValue="" name="" id="">
                <option disabled value="">
                  Select...
                </option>
                {sampleOptions.map((option) => (
                  <option key={option.value} value={option.value}>
                    {option.label}
                  </option>
                ))}
              </select>
            </div>
            <div className="FormGroup">
              <label>Custom React Select</label>
              <SelectField
                options={sampleOptions}
                isSearchable={false}
                name="select"
                value={values.select}
                onChange={setFieldValue}
                onFocus={setFieldTouched}
                className={classNames('FormControlSelect', {
                  'FormControl--invalid': touched.select && errors.select,
                })}
              />
            </div>
            <div className="FormGroup">
              <label>Custom Select disabled</label>
              <SelectField
                options={sampleOptions}
                isSearchable={false}
                name="select"
                value={values.select}
                onChange={setFieldValue}
                onFocus={setFieldTouched}
                className={classNames('FormControlSelect', {
                  'FormControl--invalid': touched.select && errors.select,
                })}
                disabled={true}
                placeholder="Select placeholder"
              />
            </div>
            <div className="FormGroup">
              <label>Date</label>
              <DatePickerField
                name="date2"
                value={values.date2}
                onChange={setFieldValue}
                onFocus={setFieldTouched}
                className={classNames('FormControl', {
                  'FormControl--invalid': touched.date2 && errors.date2,
                })}
              />
            </div>
            <div className="FormGroup">
              <label>Date disabled</label>
              <DatePickerField
                name="date"
                value={values.date}
                onChange={setFieldValue}
                onFocus={setFieldTouched}
                className={classNames('FormControl', {
                  'FormControl--invalid': touched.date && errors.date,
                })}
                disabled={true}
                placeholder="Date placeholder"
              />
            </div>
          </div>
          <div className="FormGroup">
            <div className="FormCheck">
              <Field
                type="radio"
                name="radio"
                value="value1"
                id="radio1"
                className={classNames('FormCheck__input', {
                  'FormControl--invalid': touched.radio && errors.radio,
                })}
              />
              <label className="FormCheck__label" htmlFor="radio1">
                Toggle this custom radio
              </label>
            </div>
            <div className="FormCheck">
              <Field
                type="radio"
                name="radio"
                value="value2"
                id="radio2"
                className={classNames('FormCheck__input', {
                  'FormControl--invalid': touched.radio && errors.radio,
                })}
              />
              <label className="FormCheck__label" htmlFor="radio2">
                Or toggle this other custom radio
              </label>
            </div>
            <div className="FormCheck">
              <Field
                type="radio"
                name="radio"
                value="value3"
                id="radio3"
                className={classNames('FormCheck__input', {
                  'FormControl--invalid': touched.radio && errors.radio,
                })}
                disabled={true}
              />
              <label className="FormCheck__label" htmlFor="radio3">
                Sorry this one is disabled
              </label>
            </div>
          </div>
          <div className="FormGroup">
            <label>Custom checkbox and radio</label>
            <div className="FormCustomControl FormCustomControl--check">
              <Field
                type="checkbox"
                name="check"
                id="customCheck1"
                className={classNames('FormCustomControl__input', {
                  'FormControl--invalid': touched.check && errors.check,
                })}
              />
              <label className="FormCustomControl__label" htmlFor="customCheck1">
                Check this custom checkbox
              </label>
            </div>
            <div className="FormCustomControl FormCustomControl--switch">
              <Field
                type="checkbox"
                name="check"
                id="switch1"
                className={classNames('FormCustomControl__input', {
                  'FormControl--invalid': touched.check && errors.check,
                })}
              />
              <label className="FormCustomControl__label" htmlFor="switch1">
                Toggle custom switch
              </label>
            </div>
            <div className="FormCustomControl FormCustomControl--check">
              <Field
                type="checkbox"
                name="check2"
                id="customCheck2"
                className={classNames('FormCustomControl__input', {
                  'FormControl--invalid': touched.check2 && errors.check2,
                })}
                disabled={true}
              />
              <label className="FormCustomControl__label" htmlFor="customCheck2">
                Do not click this custom disabled checkbox
              </label>
            </div>
          </div>
          <div className="FormGroup">
            <div className="FormCustomControl FormCustomControl--radio">
              <Field
                type="radio"
                name="radio"
                value="value1"
                id="customRadio1"
                className={classNames('FormCustomControl__input', {
                  'FormControl--invalid': touched.radio && errors.radio,
                })}
              />
              <label className="FormCustomControl__label" htmlFor="customRadio1">
                Toggle this custom radio
              </label>
            </div>
            <div className="FormCustomControl FormCustomControl--radio">
              <Field
                type="radio"
                name="radio"
                value="value2"
                id="customRadio2"
                className={classNames('FormCustomControl__input', {
                  'FormControl--invalid': touched.radio && errors.radio,
                })}
              />
              <label className="FormCustomControl__label" htmlFor="customRadio2">
                Or toggle this other custom radio
              </label>
            </div>
            <div className="FormCustomControl FormCustomControl--radio">
              <Field
                type="radio"
                name="radio"
                value="value3"
                id="customRadio3"
                className={classNames('FormCustomControl__input', {
                  'FormControl--invalid': touched.radio && errors.radio,
                })}
                disabled={true}
              />
              <label className="FormCustomControl__label" htmlFor="customRadio3">
                Sorry this one is disabled
              </label>
            </div>
          </div>
          <button type="submit" className="Button" disabled={!isEmpty(errors) || isEmpty(touched)}>
            Gå videre
          </button>
          <pre style={{ whiteSpace: 'pre-wrap', lineBreak: 'anywhere', fontSize: '12px' }}>{JSON.stringify(errors)}</pre>
        </Form>
      )}
    />
  );
};
