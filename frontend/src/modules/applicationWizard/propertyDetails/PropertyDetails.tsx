import * as React from 'react';
import { Form, Formik, FormikProps } from 'formik';
import * as Yup from 'yup';
import { InputField } from '../../../shared/forms/Input/InputField';
import '../../../shared/forms/button.css';
import { RadioGroupField } from '../../../shared/forms/RadioGroup/RadioGroupField';
import { Button, Col, Radio, Row, Divider } from 'antd';
import { useAppContext } from '../../../AppState/AppContext';
import { PropertyOwnershipType } from '../ApplicationDto';

interface IPropertyDetailsStepProps {
  onCompleted: () => void;
}

type FormValues = {
  propertyRegistrationNumber: string;
  district: string;
  buildingArea: string;
  propertyOwnershipType: number;
};

const FormSchema = Yup.object().shape<FormValues>({
  propertyRegistrationNumber: Yup.string().required(),
  district: Yup.string().required(),
  buildingArea: Yup.string(),
  propertyOwnershipType: Yup.number().required(),
});

export const PropertyDetails: React.FC<IPropertyDetailsStepProps> = ({ onCompleted }) => {
  const [state, actions] = useAppContext();

  const onSubmit = (form: FormValues) => {
    console.log(form); // TODO: fill state

    const { propertyRegistrationNumber, district } = form;
    actions.updateApplication({
      propertyOwnershipType: PropertyOwnershipType.Owner,
      plannedWorkAddressDetails: {
        commercialArea: 0, //lack
        usableArea: 0, //lack
        commercialToUsableAreaRatio: 0, //lack
        isForCommercialUse: false, //lack
        propertyRegistrationNumber,
        district,
      },
      lawParticipants: [],
    });
    onCompleted();
  };

  return (
    <section className="PropertyDetails">
      <Formik
        validationSchema={FormSchema}
        validateOnMount={true}
        initialValues={{
          propertyRegistrationNumber: '',
          district: '',
          buildingArea: state.area.toString() || '',
          propertyOwnershipType: PropertyOwnershipType.Owner,
        }}
        onSubmit={onSubmit}
      >
        {({ values, setFieldValue, setFieldTouched, isValid }: FormikProps<FormValues>) => (
          <Form>
            <InputField
              id="propertyRegistrationNumber"
              type="text"
              value={values.propertyRegistrationNumber}
              name="propertyRegistrationNumber"
              onChange={setFieldValue}
              onFocus={setFieldTouched}
            >
              Numer ewidencyjny działki
            </InputField>
            <InputField id="district" type="text" value={values.district} name="district" onChange={setFieldValue} onFocus={setFieldTouched}>
              Obręb działki
            </InputField>
            <Divider />
            <RadioGroupField
              id="propertyOwnershipType"
              value={values.propertyOwnershipType + ''}
              name="propertyOwnershipType"
              onChange={setFieldValue}
              items={() => (
                <>
                  <Row>
                    <Col span={8}>
                      <Radio value={PropertyOwnershipType.Owner}>Własność</Radio>
                    </Col>
                    <Col span={8}>
                      <Radio value={PropertyOwnershipType.CoOwner}>Współwłasność</Radio>
                    </Col>
                  </Row>
                  <Row>
                    <Col span={8}>
                      <Radio value={PropertyOwnershipType.RestrictionsPropertyLaw}>Użytkowanie wieczyste</Radio>
                    </Col>
                    <Col span={8}>
                      <Radio value={PropertyOwnershipType.PermanentManagement}>Trwały zarząd</Radio>
                    </Col>
                  </Row>
                  <Row>
                    <Col span={8}>
                      <Radio value={PropertyOwnershipType.RestrictionsPropertyLaw}>Ograniczone prawo rzeczowe</Radio>
                    </Col>
                    <Col span={8}>
                      <Radio value={PropertyOwnershipType.Other}>Inny</Radio>
                    </Col>
                  </Row>
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
