import * as React from 'react';
import { Form, Formik, FormikProps } from 'formik';
import * as Yup from 'yup';
import { InputField } from '../../../shared/forms/Input/InputField';
import '../../../shared/forms/button.css';
import { RadioGroupField } from '../../../shared/forms/RadioGroup/RadioGroupField';
import { Button, Col, Divider, Radio, Row } from 'antd';
import { useAppContext } from '../../../AppState/AppContext';

interface IApplicantDetailsStepProps {
  onCompleted: () => void;
}

type FormValues = {
  firstName: string;
  lastName: string;
  phoneNumber: string;
  typdzialanosci: string;
  streetName: string;
  buildingNumber: string;
  houseNumber: string;
  city: string;
  bankNumber: string;
};

const FormSchema = Yup.object().shape<FormValues>({
  firstName: Yup.string().required(),
  lastName: Yup.string().required(),
  phoneNumber: Yup.string().required(),
  typdzialanosci: Yup.string().required(),
  streetName: Yup.string().required(),
  buildingNumber: Yup.string().required(),
  houseNumber: Yup.string(),
  city: Yup.string().required(),
  bankNumber: Yup.string().required(),
});

export const ApplicantDetails: React.FC<IApplicantDetailsStepProps> = ({ onCompleted }) => {
  const [state] = useAppContext();

  const onSubmit = (form: FormValues) => {
    console.log(form); // TODO: fill state
    onCompleted();
  };

  return (
    <section className="ApplicantDetails">
      <Formik
        validationSchema={FormSchema}
        validateOnMount={true}
        initialValues={{
          firstName: '',
          lastName: '',
          phoneNumber: '',
          typdzialanosci: 'Brak',
          streetName: state.address?.street || '',
          buildingNumber: state.address?.buildingNumber || '',
          houseNumber: state.address?.houseNumber || '',
          city: state.address?.city || '',
          bankNumber: '',
        }}
        onSubmit={onSubmit}
      >
        {({ values, setFieldValue, setFieldTouched, isValid }: FormikProps<FormValues>) => (
          <Form>
            <InputField
              id="firstName"
              type="text"
              value={values.firstName}
              name="firstName"
              onChange={setFieldValue}
              onFocus={setFieldTouched}
            >
              Imię
            </InputField>
            <InputField
              id="lastName"
              type="text"
              value={values.lastName}
              name="lastName"
              onChange={setFieldValue}
              onFocus={setFieldTouched}
            >
              Nazwisko
            </InputField>
            <InputField
              id="phoneNumber"
              type="text"
              value={values.phoneNumber}
              name="phoneNumber"
              onChange={setFieldValue}
              onFocus={setFieldTouched}
            >
              Telefon
            </InputField>
            <RadioGroupField
              id="typdzialanosci"
              value={values.typdzialanosci}
              name="typdzialanosci"
              onChange={setFieldValue}
              items={() => (
                <>
                  <Row>
                    <Radio value="Brak">Brak</Radio>
                  </Row>
                  <Row>
                    <Radio value="Gospodarcza">Działalność gospodarcza</Radio>
                  </Row>
                  <Row>
                    <Radio value="Rolnicza">Działalność rolnicza</Radio>
                  </Row>
                  <Row>
                    <Radio value="Rybolowstwo">Działalność w zakresie rybołówstwa i akwakultury</Radio>
                  </Row>
                </>
              )}
            >
              Rodzaj prowadzonej działalności
            </RadioGroupField>
            <Divider />
            <h5>Lokalizacja planowanych prac</h5>
            <InputField
              id="streetName"
              type="text"
              value={values.streetName}
              name="streetName"
              onChange={setFieldValue}
              onFocus={setFieldTouched}
            >
              Ulica
            </InputField>
            <Row gutter={24}>
              <Col span={12}>
                <InputField
                  id="buildingNumber"
                  type="text"
                  value={values.buildingNumber}
                  name="buildingNumber"
                  onChange={setFieldValue}
                  onFocus={setFieldTouched}
                >
                  Numer budynku
                </InputField>
              </Col>
              <Col span={12}>
                <InputField
                  id="houseNumber"
                  type="text"
                  value={values.houseNumber}
                  name="houseNumber"
                  onChange={setFieldValue}
                  onFocus={setFieldTouched}
                >
                  Numer lokalu
                </InputField>
              </Col>
            </Row>
            <InputField id="city" type="text" value={values.city} name="city" onChange={setFieldValue} onFocus={setFieldTouched}>
              Miejscowość
            </InputField>
            <Divider />
            <h5>Rachunek bankowy wnioskodawcy</h5>
            <InputField
              id="bankNumber"
              type="text"
              value={values.bankNumber}
              name="bankNumber"
              onChange={setFieldValue}
              onFocus={setFieldTouched}
            >
              Numer rachunku
            </InputField>
            <Row >
              <Col offset={14} span={10}>
              <Button disabled={!isValid} className="Button" type="primary" htmlType="submit">
                Dalej
                </Button>
              </Col>
            </Row>
          </Form>
        )}
      </Formik>
    </section>
  );
};
