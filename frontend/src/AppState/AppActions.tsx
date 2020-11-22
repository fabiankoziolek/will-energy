import { StoreActionApi } from 'react-sweet-state';
import { DocumentContract } from '../modules/applicationWizard/ApplicationDto';
import { GoogleAddressIncome, StreetMediaDto } from '../shared/forms/GoogleSuggest/GoogleSuggest';
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
  setAdressMedia: (addressMedia: StreetMediaDto) => ({ setState, getState }: AppStoreApi) => {
    setState({
      ...getState(),
      media: addressMedia,
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
  updateApplication: (application: Partial<DocumentContract>) => ({ setState, getState }: AppStoreApi) => {
    setState({
      ...getState(),
      application: { ...getState().application, ...application },
    });
  },
};

export type Actions = typeof actions;
