import { Button, Steps } from 'antd';
import * as React from 'react';
import { FillFormStep } from '../shared/fillFormStep/FillFormStep';
import { AddressStep } from './addressStep/AddressStep';

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
    <div className="ChangeFurnacePage">
      <Steps current={step}>
        <Step />
        <Step />
        <Step />
      </Steps>

      {step === ChangeFurnaceStep.Address && <AddressStep goToNextStep={goToNextStep} />}
      {step === ChangeFurnaceStep.Calculator && (
        <div>
          calculator <Button onClick={() => goToNextStep()}> Go to next Step</Button>
        </div>
      )}
      {step === ChangeFurnaceStep.FillForm && <FillFormStep />}
    </div>
  );
};
