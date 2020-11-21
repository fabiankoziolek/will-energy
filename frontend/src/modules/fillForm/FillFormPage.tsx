import { Col, Row } from 'antd';
import * as React from 'react';
import { FillFormStep } from '../shared/fillFormStep/FillFormStep';

export const FillFormPage = () => {
  return (
    <div className="FillFormPage">
      <Row>
        <Col offset={4} span={16}>
          <FillFormStep />
        </Col>
      </Row>
    </div>
  );
};
