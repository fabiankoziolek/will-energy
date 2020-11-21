import { Col, Row, Collapse, Button } from 'antd';
import * as React from 'react';
import * as Icon from 'react-feather';
import { useAppContext } from '../../AppState/AppContext';
import { WizardStep } from '../../AppState/AppState';
import './ApplicationWizard.css';
import { ApplicantDetails } from './applicantDetails/ApplicantDetails';

const { Panel } = Collapse;

export const ApplicationWizard = () => {
  const [activeStep, setActiveStep] = React.useState<WizardStep>(WizardStep.ApplicantDetails);
  const [state, actions] = useAppContext();
  const isCompleted = (wizardStep: WizardStep) => state.completedApplicationSteps.indexOf(wizardStep) >= 0;

  React.useEffect(() => {
    if (state.completedApplicationSteps.length === 0) return;

    setActiveStep(state.completedApplicationSteps[state.completedApplicationSteps.length - 1] + 1);
  }, [state.completedApplicationSteps.length]);

  return (
    <div className="ApplicationWizard">
      <Row>
        <Col offset={4} span={16}>
          <h1 className="ApplicationWizard__title">Stop smog w Zduńskiej Woli</h1>
          <p className="ApplicationWizard__description">
            Wniosek o udzielenie dofinansowania na wymianę pieców węglowych na ekologiczne źródła ogrzewania
          </p>
          <Collapse
            accordion
            activeKey={[activeStep]}
            onChange={(key) => {
              key && setActiveStep(Number(key));
            }}
            ghost
          >
            <Panel
              header={
                <div>
                  <span>
                    <Icon.User /> Dane wnioskodawcy
                  </span>
                  {isCompleted(WizardStep.ApplicantDetails) && <Icon.Check />}
                </div>
              }
              key={WizardStep.ApplicantDetails}
            >
              <ApplicantDetails
                onCompleted={() => {
                  isCompleted(WizardStep.ApplicantDetails)
                    ? actions.uncompleteStep(WizardStep.ApplicantDetails)
                    : actions.completeStep(WizardStep.ApplicantDetails);
                }}
              />
            </Panel>
            <Panel
              header={
                <div>
                  <span>
                    <Icon.Home /> Dane nieruchomości
                  </span>
                  {isCompleted(WizardStep.PropertyDetails) && <Icon.Check />}
                </div>
              }
              key={WizardStep.PropertyDetails}
              disabled={!isCompleted(WizardStep.ApplicantDetails)}
            >
              asd a
              <Button
                onClick={() =>
                  isCompleted(WizardStep.PropertyDetails)
                    ? actions.uncompleteStep(WizardStep.PropertyDetails)
                    : actions.completeStep(WizardStep.PropertyDetails)
                }
              >
                Save
              </Button>
            </Panel>
            <Panel
              header={
                <div>
                  <span>
                    <Icon.Tool /> Charakterystyka prac
                  </span>
                  {isCompleted(WizardStep.CharacteristicsOfWorks) && <Icon.Check />}
                </div>
              }
              key={WizardStep.CharacteristicsOfWorks}
              disabled={!isCompleted(WizardStep.PropertyDetails)}
            >
              asdv
              <Button
                onClick={() =>
                  isCompleted(WizardStep.CharacteristicsOfWorks)
                    ? actions.uncompleteStep(WizardStep.CharacteristicsOfWorks)
                    : actions.completeStep(WizardStep.CharacteristicsOfWorks)
                }
              >
                Save
              </Button>
            </Panel>
            <Panel
              header={
                <div>
                  <span>
                    <Icon.File /> Podsumowanie
                  </span>
                  {isCompleted(WizardStep.Summary) && <Icon.Check />}
                </div>
              }
              key={WizardStep.Summary}
              disabled={!isCompleted(WizardStep.CharacteristicsOfWorks)}
            >
              a sdb
              <Button onClick={() => actions.completeStep(WizardStep.Summary)}>Save</Button>
            </Panel>
          </Collapse>
        </Col>
      </Row>
    </div>
  );
};
