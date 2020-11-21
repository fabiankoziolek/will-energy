import * as React from 'react';
import { Form, Formik, FormikProps, useFormikContext } from 'formik';
import * as Yup from 'yup';
import { InputField } from '../../../shared/forms/Input/InputField';
import { HeatingType } from '../../../AppState/AppState';
import axios from 'axios';
import { Line } from '@reactchartjs/react-chart.js';
import { range } from 'lodash';
import { Button, Col, Row } from 'antd';
import './CalculatorStep.css';
import '../../../shared/forms/button.css';
import * as Icon from 'react-feather';

interface ICalculatorStepProps {
  goToNextStep: () => void;
  availableTypes: HeatingType[];
}

const initialFormValues = {
  buildingArea: '50',
  heatingType: '',
};

type FormValues = typeof initialFormValues;

const FormSchema = Yup.object().shape<FormValues>({
  buildingArea: Yup.string().required(),
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

export const CalculatorStep: React.FC<ICalculatorStepProps> = ({ availableTypes, goToNextStep }) => {
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
              {({ values, setFieldValue, setFieldTouched }: FormikProps<FormValues>) => {
                return (
                  <Form>
                    <FormikNextStateListener />
                    <div className="CalculatorStep__buildingArea">
                      <InputField
                        id="BuildingArea"
                        type="text"
                        value={values.buildingArea}
                        name="buildingArea"
                        onChange={setFieldValue}
                        onFocus={setFieldTouched}
                      >
                        Podaj powierzchnię budynku w &#x33A1;
                      </InputField>
                    </div>
                    <div>
                      {availableTypes.includes(HeatingType.NetworkNaturalGas) && (
                        <InputField
                          id="NetworkNaturalGas"
                          type="radio"
                          value="NetworkNaturalGas"
                          name="heatingType"
                          onChange={setFieldValue}
                          onFocus={setFieldTouched}
                        >
                          Sieć gazowa
                        </InputField>
                      )}
                      {availableTypes.includes(HeatingType.LiquefiedNaturalGas) && (
                        <InputField
                          id="LiquefiedNaturalGas"
                          type="radio"
                          value="LiquefiedNaturalGas"
                          name="heatingType"
                          onChange={setFieldValue}
                          onFocus={setFieldTouched}
                        >
                          Gaz płynny (zbiornik)
                        </InputField>
                      )}
                      {availableTypes.includes(HeatingType.Biomass) && (
                        <InputField
                          id="Biomass"
                          type="radio"
                          value="Biomass"
                          name="heatingType"
                          onChange={setFieldValue}
                          onFocus={setFieldTouched}
                        >
                          Biomasa
                        </InputField>
                      )}
                      {availableTypes.includes(HeatingType.Electricity) && (
                        <InputField
                          id="Electricity"
                          type="radio"
                          value="Electricity"
                          name="heatingType"
                          onChange={setFieldValue}
                          onFocus={setFieldTouched}
                        >
                          Energia elektryczna
                        </InputField>
                      )}
                      {availableTypes.includes(HeatingType.NetworkHeat) && (
                        <InputField
                          id="NetworkHeat"
                          type="radio"
                          value="NetworkHeat"
                          name="heatingType"
                          onChange={setFieldValue}
                          onFocus={setFieldTouched}
                        >
                          Ciepło sieciowe
                        </InputField>
                      )}
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
          <Button type="primary" className="Button" onClick={() => goToNextStep()}>
            Sprawdź warunki
            <Icon.ArrowRight />
          </Button>
        </div>
      </div>
    </section>
  );
};
