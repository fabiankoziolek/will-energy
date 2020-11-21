import * as React from 'react';
import GooglePlacesAutocomplete from 'react-google-places-autocomplete';
import './GoogleSuggest.css';
const MY_API_KEY = 'AIzaSyDp5Jmo11YFwQY14Fts4d8kH1S1dVauHug';

export interface StreetMediaDto {
  hasGasConnection: boolean;
  hasHeatConnection: boolean;
  gasDateConnection: Date;
  heatDateConnection: Date;
}

export type GoogleAddressIncome = {
  country: string;
  city: string;
  street: string;
  buildingNumber: string;
  houseNumber: string;
};

type GoogleSuggestProps = {
  onSelect: (value: GoogleAddressIncome) => void;
  placeholder: string;
};

export const GoogleSuggest = (props: GoogleSuggestProps) => {
  const [address, setAddress] = React.useState<any>();

  React.useEffect(() => {
    if (!address) {
      return;
    }

    const terms = address.value.terms;
    if (terms.length === 3) {
      const streetTemp = terms[0].value.split(' ');
      const street = streetTemp[0];
      const city = terms[1].value;
      const country = terms[2].value;
      let buildingNumber, houseNumber;
      if (streetTemp[1]) {
        const buildingTemp = streetTemp[1].split('/');
        buildingNumber = buildingTemp[0];
        houseNumber = buildingTemp[1];
      }

      props.onSelect({ street, city, country, buildingNumber, houseNumber });
    }

    if (terms.length === 4) {
      const street = terms[0].value;
      const city = terms[2].value;
      const country = terms[3].value;
      let buildingNumber, houseNumber;
      if (terms[1].value) {
        const buildingTemp = terms[1].value.split('/');
        buildingNumber = buildingTemp[0];
        houseNumber = buildingTemp[1];
      }

      props.onSelect({ street, city, country, buildingNumber, houseNumber });
    }
  }, [address]);

  return (
    <div className="GoogleSuggest">
      <GooglePlacesAutocomplete
        apiKey={MY_API_KEY}
        autocompletionRequest={{
          componentRestrictions: {
            country: 'pl',
          },
          radius: 2500,
          location: { lat: 51.599252, lng: 18.940955 },
        }}
        selectProps={{
          placeholder: props.placeholder,
          value: address,
          noOptionsMessage: () => 'Wybacz ale nie jestem wstanie znaleźć adresu - spróbuj wyszukać w formacje np. Cicha 12, Zduńska Wola',
          loadingMessage: () => 'Szukam wyników',
          onChange: setAddress,
          filterOption: (option: any) => {
            return option.label.indexOf('Zduńska') > 0;
          },
        }}
      />
    </div>
  );
};
