import * as React from 'react';
import { Form, Formik, FormikProps } from 'formik';
import * as Yup from 'yup';
import { InputField } from '../../../shared/forms/Input/InputField';
import '../../../shared/forms/button.css';
import { RadioGroupField } from '../../../shared/forms/RadioGroup/RadioGroupField';
import { Button, Col, Radio, Row, Divider } from 'antd';
import { useAppContext } from '../../../AppState/AppContext';
import { SelectField } from '../../../shared/forms/Select/SelectField';
import { DatePickerField } from '../../../shared/forms/DatePicker/DatePickerField';
import { HeatingType } from '../ApplicationDto';

interface IPropertyDetailsStepProps {
  onCompleted: () => void;
}

type FormValues = {
  oldType: string;
  oldAge: number;
  oldPower: number;
  oldConsumption: number;
  plannedType: HeatingType;
  plannedPower: number;
  plannedConsumption: number;
  plannedCompletionDate: string;
  estimatedCost: number;
};

const FormSchema = Yup.object().shape<FormValues>({
  oldType: Yup.string().required(),
  oldAge: Yup.number().required(),
  oldPower: Yup.number().required(),
  oldConsumption: Yup.number().required(),
  plannedType: Yup.number().required(),
  plannedPower: Yup.number().required(),
  plannedConsumption: Yup.number().required(),
  plannedCompletionDate: Yup.string().required(),
  estimatedCost: Yup.number().required(),
});

export const CharacteristicsOfWorks: React.FC<IPropertyDetailsStepProps> = ({ onCompleted }) => {
  const [state, actions] = useAppContext();

  const onSubmit = (form: FormValues) => {
    console.log(form); // TODO: fill state
    const {
      oldType,
      oldAge,
      oldPower,
      oldConsumption,
      plannedType,
      plannedCompletionDate,
      plannedConsumption,
      plannedPower,
      estimatedCost,
    } = form;

    actions.updateApplication({
      oldEnergyCharacteristics: {
        // type: oldType,
        type: HeatingType.LiquefiedNaturalGas,
        power: oldPower,
        age: oldAge,
        consumptionPerYear: oldConsumption,
      },
      plannedEnergyCharacteristics: {
        type: plannedType,
        power: plannedPower,
        age: 0,
        consumptionPerYear: plannedConsumption,
      },
      plannedCompletionDate: new Date(plannedCompletionDate),
      estimatedCost: estimatedCost,
    });

    onCompleted();
  };

  return (
    <section className="PropertyDetails">
      <Formik
        validationSchema={FormSchema}
        validateOnMount={true}
        initialValues={{
          oldType: '',
          oldAge: 0,
          oldPower: 0,
          oldConsumption: 0,
          plannedType: HeatingType.NetworkNaturalGas,
          plannedPower: 0,
          plannedConsumption: 0,
          plannedCompletionDate: '',
          estimatedCost: 0,
        }}
        onSubmit={onSubmit}
      >
        {({ values, setFieldValue, setFieldTouched, isValid }: FormikProps<FormValues>) => (
          <Form>
            <h5 className="ApplicationWizard__subtitle">Dotychczasowe źródło ciepła</h5>
            <InputField id="oldType" type="text" value={values.oldType} name="oldType" onChange={setFieldValue} onFocus={setFieldTouched}>
              Rodzaj
            </InputField>
            <InputField id="oldAge" type="text" value={values.oldAge + ''} name="oldAge" onChange={setFieldValue} onFocus={setFieldTouched}>
              Wiek
            </InputField>
            <InputField
              id="oldPower"
              type="text"
              value={values.oldPower + ''}
              name="oldPower"
              onChange={setFieldValue}
              onFocus={setFieldTouched}
            >
              Moc
            </InputField>
            <InputField
              id="oldConsumption"
              type="text"
              value={values.oldConsumption + ''}
              name="oldConsumption"
              onChange={setFieldValue}
              onFocus={setFieldTouched}
            >
              Roczne zużycie paliw
            </InputField>
            <Divider />
            <h5 className="ApplicationWizard__subtitle">Planowane źródło ciepła</h5>
            <RadioGroupField
              id="plannedType"
              value={values.plannedType as any}
              name="plannedType"
              onChange={setFieldValue}
              items={() => (
                <>
                  <Row>
                    <Col span={8}>
                      <Radio value={HeatingType.NetworkHeat}>Sieć ciepłownicza</Radio>
                    </Col>
                    <Col span={8}>
                      <Radio value={HeatingType.NetworkNaturalGas}>Sieć gazowa</Radio>
                    </Col>
                  </Row>
                  <Row>
                    <Col span={8}>
                      <Radio value={HeatingType.LiquefiedNaturalGas}>Gaz płynny (zbiornik)</Radio>
                    </Col>
                    <Col span={8}>
                      <Radio value={HeatingType.Electricity}>Energia elektryczna</Radio>
                    </Col>
                  </Row>
                  <Row>
                    <Col span={8}>
                      <Radio value={HeatingType.Biomass}>Biomasa</Radio>
                    </Col>
                  </Row>
                  <InputField
                    id="plannedPower"
                    type="text"
                    value={values.plannedPower + ''}
                    name="plannedPower"
                    onChange={setFieldValue}
                    onFocus={setFieldTouched}
                  >
                    Moc
                  </InputField>
                  <InputField
                    id="plannedConsumption"
                    type="text"
                    value={values.plannedConsumption + ''}
                    name="plannedConsumption"
                    onChange={setFieldValue}
                    onFocus={setFieldTouched}
                  >
                    Planowane roczne zużycie paliw
                  </InputField>
                  <Divider />
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
                    value={values.estimatedCost + ''}
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
            <Row>
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
