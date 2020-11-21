import * as React from 'react';
import { Form, Formik, FormikProps, useFormikContext } from 'formik';
import * as Yup from 'yup';
import { InputField } from '../../../shared/forms/Input/InputField';
import { HeatingType } from '../../../AppState/AppState';
import { Link } from 'react-router-dom';
import axios from 'axios';
import { Line } from '@reactchartjs/react-chart.js';
import { range } from 'lodash';
import { Button, Col, Row } from 'antd';
import './CalculatorStep.css';
import '../../../shared/forms/button.css';
import { routes } from '../../../routes';
import classNames from 'classnames';

interface ICalculatorStepProps {
  goToNextStep: () => void;
  availableTypes: HeatingType[];
}

const initialFormValues = {
  buildingArea: '50',
  heatingType: 'NetworkNaturalGas', //TODO: wybierz najtańsze
};

type FormValues = typeof initialFormValues;

const FormSchema = Yup.object().shape<FormValues>({
  buildingArea: Yup.string().required('Powierzchnia budynku jest wymagana'),
  heatingType: Yup.string().required(),
});

interface CalculateCostsDto {
  installationCost: number;
  monthlyUsageCost: number;
  reports: ReportHeatingType[];
}

interface ReportHeatingType {
  type: string;
  costRecords: HeatingCostRecord[];
}

interface HeatingCostRecord {
  date: string;
  cost: number;
}

const FormikNextStateListener = () => {
  const { values, submitForm } = useFormikContext();
  React.useEffect(() => {
    submitForm();
  }, [values]);

  return null;
};

export const CalculatorStep: React.FC<ICalculatorStepProps> = ({ availableTypes }) => {
  const [results, setResults] = React.useState<CalculateCostsDto>();
  const [heatingType, setHeatingType] = React.useState<string>();

  const data = {
    labels: range(0, 120),
    datasets:
      results?.reports.map((x, index) => {
        return {
          label: x.type,
          data: x.costRecords.map((y) => y.cost),
          fill: false,
          backgroundColor: x.type === heatingType ? 'rgba(255, 99, 132, 1)' : 'rgba(0, 0, 0, 0.1)',
          borderColor: x.type === heatingType ? 'rgba(255, 99, 132, 1)' : 'rgba(0, 0, 0, 0.2)',
          yAxisID: 'y-axis-' + index,
        };
      }) || [],
  };

  const options = {
    scales: {
      yAxes: results?.reports.map((x, index) => {
        return {
          type: 'linear',
          display: index === 0,
          position: 'left',
          id: 'y-axis-' + index,
          ticks: {
            beginAtZero: true, // minimum value will be 0.
          },
        };
      }),
      xAxes: [
        {
          ticks: {
            autoSkip: true,
            maxTicksLimit: 20,
          },
        },
      ],
    },
  };

  const onSubmit = (form: FormValues) => {
    if (form.buildingArea && form.heatingType) {
      axios
        .get<CalculateCostsDto>(`http://localhost:5000/api/calculator?buildingArea=${form.buildingArea}&heatingType=${form.heatingType}`)
        .then((x) => {
          setResults(x.data);
          setHeatingType(form.heatingType);
        });
    }
  };

  return (
    <section className="CalculatorStep">
      <div className="CalculatorStep__message">
        <Row>
          <Col offset={4} span={16}>
            <h1 className="CalculatorStep__messageTitle">Świetna wiadomość!</h1>
            <p className="CalculatorStep__messageDescription">
              W Twojej okolicy możesz skorzystać z <strong>{availableTypes.length} alternatywnych źródeł ogrzewania</strong>
            </p>
            <h2 className="CalculatorStep__messageSubTitle">Ile to kosztuje?</h2>
            <p className="CalculatorStep__messageDescription">
              Skorzystaj z <strong>kalkulatora</strong> kosztów ogrzewania, aby wybrać najlepsze rozwiązanie dla siebie
            </p>
          </Col>
        </Row>
      </div>
      <div className="CalculatorStep__messageFooter" />
      <div className="CalculatorStep__calculator">
        <Row>
          <Col offset={4} span={16}>
            <Formik validationSchema={FormSchema} initialValues={initialFormValues} onSubmit={onSubmit}>
              {({ values, setFieldValue, setFieldTouched, errors }: FormikProps<FormValues>) => {
                return (
                  <Form>
                    <FormikNextStateListener />
                    <div className="CalculatorStep__buildingArea">
                      <InputField
                        id="BuildingArea"
                        type="number"
                        value={values.buildingArea}
                        name="buildingArea"
                        onChange={setFieldValue}
                        onFocus={setFieldTouched}
                        error={errors.buildingArea}
                      >
                        Podaj powierzchnię budynku w &#x33A1;
                      </InputField>
                    </div>
                    <div className="CalculatorStep__heatingType">
                      <Row>
                        {availableTypes.includes(HeatingType.NetworkNaturalGas) && (
                          <Col span={6}>
                            <div className="CalculatorStep__heatingTypeElement">
                              <Button
                                id="NetworkNaturalGas"
                                name="heatingType"
                                onClick={() => setFieldValue('heatingType', 'NetworkNaturalGas')}
                                className={classNames('Button', { 'Button--active': values.heatingType === 'NetworkNaturalGas' })}
                                type="primary"
                              >
                                Sieć gazowa
                              </Button>
                            </div>
                          </Col>
                        )}
                        {availableTypes.includes(HeatingType.LiquefiedNaturalGas) && (
                          <Col span={6}>
                            <div className="CalculatorStep__heatingTypeElement">
                              <Button
                                id="LiquefiedNaturalGas"
                                name="heatingType"
                                onClick={() => setFieldValue('heatingType', 'LiquefiedNaturalGas')}
                                className={classNames('Button', { 'Button--active': values.heatingType === 'LiquefiedNaturalGas' })}
                                type="primary"
                              >
                                Gaz płynny (zbiornik)
                              </Button>
                            </div>
                          </Col>
                        )}
                        {availableTypes.includes(HeatingType.Biomass) && (
                          <Col span={6}>
                            <div className="CalculatorStep__heatingTypeElement">
                              <Button
                                id="Biomass"
                                name="heatingType"
                                onClick={() => setFieldValue('heatingType', 'Biomass')}
                                className={classNames('Button', { 'Button--active': values.heatingType === 'Biomass' })}
                                type="primary"
                              >
                                Biomasa
                              </Button>
                            </div>
                          </Col>
                        )}
                        {availableTypes.includes(HeatingType.Electricity) && (
                          <Col span={6}>
                            <div className="CalculatorStep__heatingTypeElement">
                              <Button
                                id="Electricity"
                                name="heatingType"
                                onClick={() => setFieldValue('heatingType', 'Electricity')}
                                className={classNames('Button', { 'Button--active': values.heatingType === 'Electricity' })}
                                type="primary"
                              >
                                Energia elektryczna
                              </Button>
                            </div>
                          </Col>
                        )}
                        {availableTypes.includes(HeatingType.NetworkHeat) && (
                          <Col span={6}>
                            <div className="CalculatorStep__heatingTypeElement">
                              <Button
                                id="NetworkHeat"
                                name="heatingType"
                                onClick={() => setFieldValue('heatingType', 'NetworkHeat')}
                                className={classNames('Button', { 'Button--active': values.heatingType === 'NetworkHeat' })}
                                type="primary"
                              >
                                Ciepło sieciowe
                              </Button>
                            </div>
                          </Col>
                        )}
                      </Row>
                    </div>
                  </Form>
                );
              }}
            </Formik>
            <div>
              <div>
                <span>Szacunkowy</span>
                <span>Koszt instalacji ogrzewania</span>
                <span>obejmuje koszt projektu i instalacji</span>
                <span>{results?.installationCost || '-'} zł</span>
              </div>
              <div>
                <span>Szacunkowy</span>
                <span>Miesięczny koszt ogrzewania </span>
                <span>obejmuje koszt ogrzewania budynku i podgrzania wody</span>
                <span>{results?.monthlyUsageCost || '-'} zł</span>
              </div>
            </div>
            <div>
              <div>Całkowity koszt inwestycji</div>

              {results && heatingType && (
                <div>
                  <Line type="line" data={data} options={options} />
                </div>
              )}
              <div>Kolejne lata</div>
            </div>
          </Col>
        </Row>
      </div>
      <div className="CalculatorStep__calculatorMessage">
        <div className="CalculatorStep__calculatorMessageInner">
          <h2>Jak zmniejszyć koszty instalacji?</h2>
          <p>
            {`Newton's laws of motion and universal gravitation, the laws of conservation of energy and momentum, the laws of thermodynamics,
            and Maxwell's equations for electricity and magnetism were all more or less nearly complete at the end of the 19th century.`}
          </p>
          <Link to={routes.checkDetails} className="LinkAsButton">
            Sprawdź warunki
          </Link>
        </div>
      </div>
    </section>
  );
};
