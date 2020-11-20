import * as React from 'react';
import { AddressStep } from './addressStep/AddressStep';

enum Step {
  Address,
  Calculator,
  FillForm,
}

export const ChangeStovePage = () => {
  const [step, setStep] = React.useState<Step>(Step.Address);

  const goToNextStep = () => {
    if (step === Step.Address) {
      setStep(Step.Calculator);
    }

    if (step === Step.Calculator) {
      setStep(Step.Calculator);
    }
  };

  return (
    <div className="ChangeStovePage">
      {step === Step.Address && <AddressStep goToNextStep={goToNextStep} />}
      {step === Step.Calculator && <div>calculator</div>}
    </div>
  );
};
