import * as React from 'react';
import './WelcomePage.css';
import imgLanding from '../../static/images/img-person-bounds.svg';
import { routes } from '../../routes';
import { Link } from 'react-router-dom';
import axios from 'axios';
import { Col, Popover, Row } from 'antd';
import * as Icon from 'react-feather';

interface SensorResultDto {
  longtitude: number;
  latitude: number;
  currentValuePm10: string;
  currentValuePm25: string;
  currentColourPm10: string;
  currentColourPm25: string;
  currentOrderNumberPm10: number;
  currentOrderNumberPm25: number;
  forecastedValuePm10: string;
  forecastedValuePm25: string;
  forecastedColourPm10: string;
  forecastedColourPm25: string;
  forecastedOrderNumberPm10: number;
  forecastedOrderNumberPm25: number;
  forecastedDateTime: string;
  street: string;
  buildingNumber: string;
  pm1: number;
  pm25: number;
  pm1number: number;
  temperatura: number;
  predkoscMax: number;
  dataGodzina: string;
  measurements: [null];
  predkosc: string;
  caqiPm25: number;
  caqiPm10: number;
}

export const WelcomePage = () => {
  const [sensorResult, setSensorResult] = React.useState<SensorResultDto>();

  React.useEffect(() => {
    axios.get<SensorResultDto>('http://localhost:5000/api/Sensors/Worst').then((x) => {
      setSensorResult(x.data);
      console.log(x.data)
    });
  }, []);

  const getSensorTextOpinion = (result: number) => {
    if (result > 75) {
      return 'Jakość powietrza jest zła';
    }

    if (result > 50) {
      return 'Jakość powietrza nie jest dzisiaj najlepsza';
    }

    return 'Jakość powietrza jest w porzadku';
  };

  return (
    <section className="WelcomePage">
      <Row>
        <Col offset={10} span={8} style={{ position: "relative", zIndex: 5 }}>
          <p className="WelcomePage__info">
            Prawie 70% domów wciąż ogrzewane jest piecami węglowymi. <br />
            <br /> Zyskaj nawet <strong>5 000 zł</strong> na wymianę swojego pieca dzięki dofinansowaniu z programu{' '}
            <strong>Stop smog</strong>
          </p>
          <Link className="LinkAsButton" to={routes.changeFurnace}>
            Dowiedz się więcej
          </Link>
        </Col>
      </Row>
      {!!sensorResult && (
        <div className="WelcomePage__messageBox">
          <h2 className="WelcomePage__messageTitle">Aktualna Jakość powietrza</h2>
          <h3 className="WelcomePage__city">Zduńska Wola</h3>
          <h4 className="WelcomePage__street">Ul. {sensorResult.street}</h4>
          <div className="WelcomePage__measureResult">
            <h5>{sensorResult.caqiPm10}</h5>
            <p>
              CAQI (PM10) <br />
              /100
            </p>
          </div>
          <p className="WelcomePage__text">{getSensorTextOpinion(sensorResult.caqiPm10)}</p>
          <Popover
            placement="bottom"
            content="CAQI to wskaźnik godzinowej jakości powietrza. Im wyższą ma wartość, tym bardziej zanieczyszczone jest powietrze, którym oddychasz."
            trigger="hover"
          >
            <Icon.Info className="WelcomePage__infoIcon" />
          </Popover>
        </div>
      )}
      <img className="WelcomePage__backgroundImage" src={imgLanding} alt="" />
    </section>
  );
};
