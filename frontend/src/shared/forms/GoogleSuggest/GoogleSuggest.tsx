import * as React from 'react';
import ReactGoogleMapLoader from 'react-google-maps-loader';
import ReactGooglePlacesSuggest from 'react-google-places-suggest';
import { Input } from 'antd';

const MY_API_KEY = 'AIzaSyDp5Jmo11YFwQY14Fts4d8kH1S1dVauHug';

export type GoogleAddressIncome = {
  locality: string;
  country: string;
  postal_code: string;
  street_number: string;
  route: string;
};

type GoogleSuggestProps = {
  onSelect: (value: GoogleAddressIncome) => void;
};

export const GoogleSuggest = (props: GoogleSuggestProps) => {
  const [address, setAddress] = React.useState('');

  const handleGoogleSuggest = (value: google.maps.GeocoderResult) => {
    const suggestedData = {} as any;
    value.address_components.forEach((el) => {
      suggestedData[el.types[0]] = el.long_name;
    });

    const typedSuggestedData = suggestedData as GoogleAddressIncome;
    if (typedSuggestedData.route && typedSuggestedData.locality) {
      setAddress(
        `${typedSuggestedData.route} ${typedSuggestedData.street_number && typedSuggestedData.street_number}, ${
          typedSuggestedData.locality
        }`,
      );
      props.onSelect(typedSuggestedData);
    }
  };

  return (
    <ReactGoogleMapLoader
      params={{
        key: MY_API_KEY,
        libraries: 'places,geocode',
      }}
      render={(googleMaps: any) =>
        googleMaps && (
          <ReactGooglePlacesSuggest
            googleMaps={googleMaps}
            autocompletionRequest={{
              bounds: { north: 18.96507, east: 51.68843, south: 18.91357, west: 51.65266 },
              input: address,
              componentRestrictions: { country: 'pl' },
            }}
            onSelectSuggest={(value) => handleGoogleSuggest(value)}
          >
            <div className="googlesuggest">
              <Input autoComplete="chrome-off" type="text" value={address} onChange={(value) => setAddress(value.target.value)} />
            </div>
          </ReactGooglePlacesSuggest>
        )
      }
    />
  );
};
