export enum HeatingType {
  NetworkNaturalGas,
  LiquefiedNaturalGas,
  Biomass,
  Electricity,
  NetworkHeat,
}

export type AppState = { address: string; area: number; heatingType?: HeatingType };

export const initialState: AppState = {
  address: '',
  area: 0,
};
