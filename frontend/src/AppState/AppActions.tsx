import { StoreActionApi } from 'react-sweet-state';
import { AppState } from './AppState';

export type AppStoreApi = StoreActionApi<AppState>;

export const actions = {
  updateBaseData: (baseData: Pick<AppState, 'address' | 'area' | 'heatingType'>) => ({ setState, getState }: AppStoreApi) => {
    setState({
      ...getState(),
      ...baseData,
    });
  },
  setAddress: (address: string) => ({ setState, getState }: AppStoreApi) => {
    setState({
      ...getState(),
      address,
    });
  },
};

export type Actions = typeof actions;
