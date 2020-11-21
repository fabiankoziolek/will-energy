import { Col, Row } from 'antd';
import * as React from 'react';
import { Link } from 'react-router-dom';
import { routes } from '../../../routes';
import './FillFormStep.css';

export const FillFormStep = () => {
  return (
    <div className="FillFormStep">
      <Row>
        <Col offset={4} span={16}>
          <h1 className="FillFormStep__title">Stop smog w Zduńskiej Woli</h1>
          <p className="FillFormStep__description">Nawet do 5 000 zł dofinansowania na wymianę pieców węglowych</p>

          <section className="FillFormStep__section">
            <h1 className="FillFormStep__sectionTitle">Kto może wystąpić o dotację?</h1>
            <ul className="FillFormStep__sectionList">
              <li>osoby fizyczne</li>
              <li>wspólnony mieszkaniowe</li>
              <li>przedsiębiorcy</li>
              <li>osoby prawne</li>
              <li>jednostki sektora finansów publicznych</li>
            </ul>
            <span>
              dysponujące prawem własności, współwłasności lub użytkowania wieczystego do położonej w naszym mieście nieruchomości, w której
              zainstalowano piec węglowy
            </span>
          </section>

          <section className="FillFormStep__section">
            <h1 className="FillFormStep__sectionTitle">Na co można przeznaczyć dotację?</h1>
            <span>Przyznane środki możesz przeznaczyć na wymianę pieca opalanego węglem na:</span>
            <ul className="FillFormStep__sectionList">
              <li>kocioł na biomase</li>
              <li>kocioł na płynny gaz</li>
              <li>ogrzewanie elektryczne</li>
              <li>przyłączenie budynku do sieci ciepłowniczej</li>
              <li>podłączenie budynku do sieci gazowej</li>
            </ul>
            <span>
              dysponujące prawem własności, współwłasności lub użytkowania wieczystego do położonej w naszym mieście nieruchomości, w której
              zainstalowano piec węglowy
            </span>
          </section>

          <p>
            Więcej informacji znajdziesz w{' '}
            <a
              target="blank"
              href="http://zdunskawola.pl/pl/aktualnosci/1494-stop-smog-mamy-nowy-regulamin-przyznawania-dotacji-na-wymiane-piecow-weglowych"
            >
              Regulaminie przyznawania dotacji
            </a>
          </p>
          <div className="FillFormStep__buttons">
            <Link className="LinkAsButton" to={routes.applicationWizard}>
              Wypełnij wniosek
            </Link>
            <a className="LinkAsButton--outline" target="blank" href="http://zdunskawola.pl/images/luty_2020/Wniosek_z_zalacznikami.pdf">
              Pobierz pdf
            </a>
          </div>
        </Col>
      </Row>
    </div>
  );
};
