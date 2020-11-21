import { Button, Col, Row, Steps } from 'antd';
import * as React from 'react';
import { FillFormStep } from '../shared/fillFormStep/FillFormStep';
import { AddressStep } from './addressStep/AddressStep';
import './ChangeFurnacePage.css';
import './StepBase.css';

enum ChangeFurnaceStep {
  Address,
  Calculator,
  FillForm,
}

const { Step } = Steps;

export const ChangeFurnacePage = () => {
  const [step, setStep] = React.useState<ChangeFurnaceStep>(ChangeFurnaceStep.Address);

  const goToNextStep = () => {
    if (step === ChangeFurnaceStep.Address) {
      setStep(ChangeFurnaceStep.Calculator);
    }

    if (step === ChangeFurnaceStep.Calculator) {
      setStep(ChangeFurnaceStep.FillForm);
    }
  };

  return (
    <section className="StepBase ChangeFurnacePage">
      <div className="StepBase__inner">
        <div className="ChangeFurnacePage__steps">
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
        {step === ChangeFurnaceStep.Calculator && (
          <div>
            calculator <Button onClick={() => goToNextStep()}> Go to next Step</Button>
          </div>
        )}
        {step === ChangeFurnaceStep.FillForm && <FillFormStep />}
      </div>
    </section>
  );
};
