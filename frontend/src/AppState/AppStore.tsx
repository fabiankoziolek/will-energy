import { createStore } from 'react-sweet-state';
import { Actions, actions } from './AppActions';
import { AppState, initialState } from './AppState';

export const AppStore = createStore<AppState, Actions>({
  initialState,
  actions,
});
