import { Checkbox, Input } from 'antd';
import * as React from 'react';
import { Link } from 'react-router-dom';
import { useAppContext } from '../../../AppState/AppContext';

interface IAddressStepProps {
  goToNextStep: () => void;
}

const { Search } = Input;

export const AddressStep: React.FC<IAddressStepProps> = (props) => {
  const [isPrivacyPolicyAccepted, setPrivacyPolicy] = React.useState(false);

  const [state, actions] = useAppContext();

  return (
    <div className="AddressStep">
      <h1>Zadbaj o powietrze w Zduńskiej Woli</h1>
      <br />
      <p>Podaj swój adres i sprawdź możliwość zmiany źródła ogrzewania</p>

      <Checkbox onChange={(e) => setPrivacyPolicy(e.target.checked)}>
        Znam i akcjeptuję <Link to={'/polityka'}>Politykę prywatności</Link>
      </Checkbox>

      <Search
        placeholder="Wpisz swój adres, np. Cicha 12, Zduńska Wola"
        enterButton="Sprawdź"
        size="large"
        onSearch={(value) => {
          actions.setAddress(value);
          props.goToNextStep();
        }}
        disabled={!isPrivacyPolicyAccepted}
      />
    </div>
  );
};
