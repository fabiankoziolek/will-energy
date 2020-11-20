import { StoreActionApi } from 'react-sweet-state';
import { AppState } from './AppState';

export type AppStoreApi = StoreActionApi<AppState>;

export const actions = {
  increment: (by = 1) => ({ setState, getState }: AppStoreApi) => {
    setState({
      count: getState().count + by,
    });
  },
};

export type Actions = typeof actions;
