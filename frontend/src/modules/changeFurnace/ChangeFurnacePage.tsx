import { Button } from 'antd';
import * as React from 'react';
import { FillFormStep } from '../shared/fillFormStep/FillFormStep';
import { AddressStep } from './addressStep/AddressStep';

enum Step {
  Address,
  Calculator,
  FillForm,
}

export const ChangeFurnacePage = () => {
  const [step, setStep] = React.useState<Step>(Step.Address);

  const goToNextStep = () => {
    if (step === Step.Address) {
      setStep(Step.Calculator);
    }

    if (step === Step.Calculator) {
      setStep(Step.FillForm);
    }
  };

  return (
    <div className="ChangeFurnacePage">
      {step === Step.Address && <AddressStep goToNextStep={goToNextStep} />}
      {step === Step.Calculator && (
        <div>
          calculator <Button onClick={() => goToNextStep()}> Go to next Step</Button>
        </div>
      )}
      {step === Step.FillForm && <FillFormStep />}
    </div>
  );
};
