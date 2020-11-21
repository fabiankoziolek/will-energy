import { GoogleAddressIncome } from '../shared/forms/GoogleSuggest/GoogleSuggest';

export enum HeatingType {
  NetworkNaturalGas,
  LiquefiedNaturalGas,
  Biomass,
  Electricity,
  NetworkHeat,
}

export type AppState = { address?: GoogleAddressIncome; area: number; heatingType?: HeatingType };

export const initialState: AppState = {
  address: undefined,
  area: 0,
};
