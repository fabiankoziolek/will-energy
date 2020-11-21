import * as React from 'react';
import { Form, Formik, FormikProps } from 'formik';
import * as Yup from 'yup';
import { InputField } from '../../../shared/forms/Input/InputField';
import '../../../shared/forms/button.css';
import { RadioGroupField } from '../../../shared/forms/RadioGroup/RadioGroupField';
import { Button, Col, Radio, Row } from 'antd';
import { useAppContext } from '../../../AppState/AppContext';
import { SelectField } from '../../../shared/forms/Select/SelectField';
import {DatePickerField} from "../../../shared/forms/DatePicker/DatePickerField";

interface IPropertyDetailsStepProps {
  onCompleted: () => void;
}

type FormValues = {
  oldType: string;
  oldAge: string;
  oldPower: string;
  oldConsumption: string;
  plannedType: string;
  plannedPower: string;
  plannedConsumption: string;
  plannedCompletionDate: string;
  estimatedCost: string;
};

const FormSchema = Yup.object().shape<FormValues>({
  oldType: Yup.string().required(),
  oldAge: Yup.string().required(),
  oldPower: Yup.string().required(),
  oldConsumption: Yup.string().required(),
  plannedType: Yup.string().required(),
  plannedPower: Yup.string().required(),
  plannedConsumption: Yup.string().required(),
  plannedCompletionDate: Yup.string(),
  estimatedCost: Yup.string().required(),
});

export const CharacteristicsOfWorks: React.FC<IPropertyDetailsStepProps> = ({ onCompleted }) => {
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
          oldType: '',
          oldAge: '',
          oldPower: '',
          oldConsumption: '',
          plannedType: '',
          plannedPower: '',
          plannedConsumption: '',
          plannedCompletionDate: '',
          estimatedCost: '',
        }}
        onSubmit={onSubmit}
      >
        {({ values, setFieldValue, setFieldTouched, isValid }: FormikProps<FormValues>) => (
          <Form>
            <h5>Dotychczasowe źródło ciepła</h5>
            <InputField id="oldType" type="text" value={values.oldType} name="oldType" onChange={setFieldValue} onFocus={setFieldTouched}>
              Rodzaj
            </InputField>
            <InputField id="oldAge" type="text" value={values.oldAge} name="oldAge" onChange={setFieldValue} onFocus={setFieldTouched}>
              Wiek
            </InputField>
            <InputField
              id="oldPower"
              type="text"
              value={values.oldPower}
              name="oldPower"
              onChange={setFieldValue}
              onFocus={setFieldTouched}
            >
              Moc
            </InputField>
            <InputField
              id="oldConsumption"
              type="text"
              value={values.oldConsumption}
              name="oldConsumption"
              onChange={setFieldValue}
              onFocus={setFieldTouched}
            >
              Roczne zużycie paliw
            </InputField>
            <hr />
            <h5>Planowane źródło ciepła</h5>
            <RadioGroupField
              id="plannedType"
              value={values.plannedType}
              name="plannedType"
              onChange={setFieldValue}
              items={() => (
                <>
                  <Row>
                    <Col>
                      <Radio value="Sieć ciepłownicza">Sieć ciepłownicza</Radio>
                    </Col>
                    <Col>
                      <Radio value="Sieć gazowa">Sieć gazowa</Radio>
                    </Col>
                  </Row>
                  <Row>
                    <Col>
                      <Radio value="Gaz płynny (zbiornik)">Gaz płynny (zbiornik)</Radio>
                    </Col>
                    <Col>
                      <Radio value="Energia elektryczna">Energia elektryczna</Radio>
                    </Col>
                  </Row>
                  <Row>
                    <Col>
                      <Radio value="Biomasa">Biomasa</Radio>
                    </Col>
                  </Row>
                  <InputField
                    id="plannedPower"
                    type="text"
                    value={values.plannedPower}
                    name="plannedPower"
                    onChange={setFieldValue}
                    onFocus={setFieldTouched}
                  >
                    Moc
                  </InputField>
                  <InputField
                    id="plannedConsumption"
                    type="text"
                    value={values.plannedConsumption}
                    name="plannedConsumption"
                    onChange={setFieldValue}
                    onFocus={setFieldTouched}
                  >
                    Planowane roczne zużycie paliw
                  </InputField>
                  <hr />
                  <DatePickerField
                    id="plannedCompletionDate"
                    value={values.plannedCompletionDate}
                    name="plannedCompletionDate"
                    onChange={setFieldValue}
                    onFocus={setFieldTouched}
                  >
                    Planowany termin zakończenia prac objętych wnioskiem
                  </DatePickerField>
                  <InputField
                    id="estimatedCost"
                    type="text"
                    value={values.estimatedCost}
                    name="estimatedCost"
                    onChange={setFieldValue}
                    onFocus={setFieldTouched}
                  >
                    Szacunkowy koszt przedsięwzięcia w zł
                  </InputField>
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
