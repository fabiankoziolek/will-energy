import * as React from 'react';
import { useAppContext } from '../../AppState/AppContext';

export function Test(props: any) {

  const [state, actions] = useAppContext();
  return (
    <div>
      {state.count}

      <button onClick={() => actions.increment(3)}>increment</button>
    </div>
  );
}
