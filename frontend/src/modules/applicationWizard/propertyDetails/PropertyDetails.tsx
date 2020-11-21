import * as React from 'react';
import { Form, Formik, FormikProps } from 'formik';
import * as Yup from 'yup';
import { InputField } from '../../../shared/forms/Input/InputField';
import '../../../shared/forms/button.css';
import { RadioGroupField } from '../../../shared/forms/RadioGroup/RadioGroupField';
import { Button, Col, Radio, Row } from 'antd';
import { useAppContext } from '../../../AppState/AppContext';

interface IPropertyDetailsStepProps {
  onCompleted: () => void;
}

type FormValues = {
  numerEwidencjiDzialki: string;
  obreb: string;
  buildingArea: string;
  tytulWlasnosci: string;
};

const FormSchema = Yup.object().shape<FormValues>({
  numerEwidencjiDzialki: Yup.string().required(),
  obreb: Yup.string().required(),
  buildingArea: Yup.string(),
  tytulWlasnosci: Yup.string().required(),
});

export const PropertyDetails: React.FC<IPropertyDetailsStepProps> = ({ onCompleted }) => {
  const [state] = useAppContext();

  const onSubmit = (form: FormValues) => {
    console.log(form); // TODO: fill state
    onCompleted();
  };

  return (
    <section className="PropertyDetails">
      <Formik
        validationSchema={FormSchema}
        validateOnMount={true}
        initialValues={{
          numerEwidencjiDzialki: '',
          obreb: '',
          buildingArea: state.area.toString() || '',
          tytulWlasnosci: 'Własność',
        }}
        onSubmit={onSubmit}
      >
        {({ values, setFieldValue, setFieldTouched, isValid }: FormikProps<FormValues>) => (
          <Form>
            <InputField
              id="numerEwidencjiDzialki"
              type="text"
              value={values.numerEwidencjiDzialki}
              name="numerEwidencjiDzialki"
              onChange={setFieldValue}
              onFocus={setFieldTouched}
            >
              Numer ewidencyjny działki
            </InputField>
            <InputField
              id="obreb"
              type="text"
              value={values.obreb}
              name="obreb"
              onChange={setFieldValue}
              onFocus={setFieldTouched}
            >
              Obręb działki
            </InputField>
            <hr />
            <RadioGroupField
              id="tytulWlasnosci"
              value={values.tytulWlasnosci}
              name="tytulWlasnosci"
              onChange={setFieldValue}
              items={() => (
                <>
                  <Row>
                    <Col>
                      <Radio value="Własność">Własność</Radio>
                    </Col>
                    <Col>
                      <Radio value="Współwłasność">Współwłasność</Radio>
                    </Col>
                  </Row>
                  <Row>
                    <Col>
                      <Radio value="UżytkowanieWieczyste">Użytkowanie wieczyste</Radio>
                    </Col>
                    <Col>
                      <Radio value="TrwałyZarząd">Trwały zarząd</Radio>
                    </Col>
                  </Row>
                  <Row>
                    <Col>
                      <Radio value="OgraniczonePrawoRzeczowe">Ograniczone prawo rzeczowe</Radio>
                    </Col>
                    <Col>
                      <Radio value="Inny">Inny</Radio>
                    </Col>
                  </Row>
                </>
              )}
            >
              Tytuł własności nieruchomości
            </RadioGroupField>
            <Button disabled={!isValid} className="Button" type="primary" htmlType="submit">
              Dalej
            </Button>
          </Form>
        )}
      </Formik>
    </section>
  );
};
