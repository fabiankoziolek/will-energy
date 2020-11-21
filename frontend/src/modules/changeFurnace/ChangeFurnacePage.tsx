import { Col, Row, Steps } from 'antd';
import * as React from 'react';
import { FillFormStep } from '../shared/fillFormStep/FillFormStep';
import { AddressStep } from './addressStep/AddressStep';
import './ChangeFurnacePage.css';
import './StepBase.css';
import { CalculatorStep } from './calculatorStep/CalculatorStep';
import { HeatingType } from '../../AppState/AppState';

enum ChangeFurnaceStep {
  Address,
  Calculator,
  FillForm,
}

const { Step } = Steps;

export const smoothScrollToSection = (id: string) => {
  const section = document.getElementById(id);
  if (section) {
    section.scrollIntoView({
      behavior: 'smooth',
    });
  }
};

export const ChangeFurnacePage = () => {
  const [step, setStep] = React.useState<ChangeFurnaceStep>(ChangeFurnaceStep.Address);
  const availableTypes = [HeatingType.NetworkNaturalGas, HeatingType.LiquefiedNaturalGas, HeatingType.Electricity, HeatingType.NetworkHeat]; // TODO: use state

  const goToNextStep = () => {
    if (step === ChangeFurnaceStep.Address) {
      setStep(ChangeFurnaceStep.Calculator);
    }

    if (step === ChangeFurnaceStep.Calculator) {
      setStep(ChangeFurnaceStep.FillForm);
    }

    smoothScrollToSection('steps');
  };

  return (
    <section className="StepBase ChangeFurnacePage">
      <div className="StepBase__inner">
        <div id="steps" className="ChangeFurnacePage__steps">
          <Row>
            <Col offset={4} span={8}>
              <Steps current={step}>
                <Step />
                <Step />
                <Step />
              </Steps>
            </Col>
          </Row>
        </div>

        {step === ChangeFurnaceStep.Address && <AddressStep goToNextStep={goToNextStep} />}
        {step === ChangeFurnaceStep.Calculator && <CalculatorStep goToNextStep={goToNextStep} availableTypes={availableTypes} />}
        {step === ChangeFurnaceStep.FillForm && <FillFormStep />}
      </div>
    </section>
  );
};
