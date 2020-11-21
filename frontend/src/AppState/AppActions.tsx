import { StoreActionApi } from 'react-sweet-state';
import { GoogleAddressIncome } from '../shared/forms/GoogleSuggest/GoogleSuggest';
import { AppState, WizardStep } from './AppState';

export type AppStoreApi = StoreActionApi<AppState>;

export const actions = {
  updateBaseData: (baseData: Pick<AppState, 'address' | 'area' | 'heatingType'>) => ({ setState, getState }: AppStoreApi) => {
    setState({
      ...getState(),
      ...baseData,
    });
  },
  setAddress: (address: GoogleAddressIncome) => ({ setState, getState }: AppStoreApi) => {
    setState({
      ...getState(),
      address,
    });
  },
  completeStep: (wizardStep: WizardStep) => ({ setState, getState }: AppStoreApi) => {
    const { completedApplicationSteps } = getState();

    if (completedApplicationSteps.indexOf(wizardStep) >= 0) {
      return;
    }

    setState({
      ...getState(),
      completedApplicationSteps: [...completedApplicationSteps, wizardStep],
    });
  },
  uncompleteStep: (wizardStep: WizardStep) => ({ setState, getState }: AppStoreApi) => {
    const { completedApplicationSteps } = getState();

    setState({
      ...getState(),
      completedApplicationSteps: completedApplicationSteps.splice(0, completedApplicationSteps.indexOf(wizardStep)),
    });
  },
};

export type Actions = typeof actions;
