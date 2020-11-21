import { GoogleAddressIncome } from '../shared/forms/GoogleSuggest/GoogleSuggest';

export enum HeatingType {
  NetworkNaturalGas,
  LiquefiedNaturalGas,
  Biomass,
  Electricity,
  NetworkHeat,
}

export enum WizardStep {
  ApplicantDetails,
  PropertyDetails,
  CharacteristicsOfWorks,
  Summary,
}

export type AppState = { address?: GoogleAddressIncome; area: number; heatingType?: HeatingType; completedApplicationSteps: WizardStep[] };

export const initialState: AppState = {
  address: undefined,
  area: 0,
  completedApplicationSteps: [],
};
