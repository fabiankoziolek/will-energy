import { Button, Checkbox, Col, Input, Row } from 'antd';
import * as React from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import { useAppContext } from '../../../AppState/AppContext';
import { GoogleAddressIncome, GoogleSuggest, StreetMediaDto } from '../../../shared/forms/GoogleSuggest/GoogleSuggest';
import './AddressStep.css';
import '../../../shared/forms/consent.css';
import '../../../shared/forms/button.css';
import { routes } from '../../../routes';

interface IAddressStepProps {
  goToNextStep: () => void;
}

export const AddressStep: React.FC<IAddressStepProps> = (props) => {
  const [isPrivacyPolicyAccepted, setPrivacyPolicy] = React.useState(false);

  const [state, actions] = useAppContext();

  const handleSubmitAdress = async () => {
    const street = state?.address?.street ?? '';
    const x = await axios.get<StreetMediaDto>(`http://localhost:5001/api/StreetMedia?streetName=${street}`);
    actions.setAdressMedia(x.data);
    props.goToNextStep();
  };

  return (
    <div className="AddressStep">
      <Row>
        <Col offset={4} span={16}>
          <h1 className="AddressStep__title">Zadbaj o powietrze w Zduńskiej Woli</h1>
          <p className="AddressStep__description">Podaj swój adres i sprawdź możliwość zmiany źródła ogrzewania</p>
          <div className="Consent">
            <Checkbox onChange={(e) => setPrivacyPolicy(e.target.checked)}>
              Znam i akcjeptuję <Link to={routes.privacyPolicy}>Politykę prywatności</Link>
            </Checkbox>
          </div>
          <Row>
            <Col span={18}>
              <GoogleSuggest
                placeholder="Wpisz swój adres, np. Cicha 12, Zduńska Wola"
                onSelect={(value: GoogleAddressIncome) => actions.setAddress(value)}
              />
            </Col>
            <Col span={6}>
              <Button
                disabled={!(isPrivacyPolicyAccepted && !!state.address)}
                onClick={() => handleSubmitAdress()}
                className="Button"
                type="primary"
              >
                Sprawdź
              </Button>
            </Col>
          </Row>
        </Col>
      </Row>
    </div>
  );
};
