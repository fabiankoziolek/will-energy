import * as React from 'react';
import { Layout, Menu } from 'antd';
import { Link, useLocation } from 'react-router-dom';
import './AppHeader.css';
import { routes } from '../../routes';

const { Header } = Layout;

export const AppHeader= () => {
  const location = useLocation();
  return (
    <Header className="AppHeader">
      <div className="AppHeader__inner">
        <div className="AppHeader__logo" />
        <Menu mode="horizontal" defaultSelectedKeys={[location.pathname]}>
          <Menu.Item key={routes.changeFurnace}>
            <Link to={routes.changeFurnace}>Zmień piec</Link>
          </Menu.Item>
          <Menu.Item key={routes.fillForm}>
            <Link to={routes.fillForm}>Dofinansowanie</Link>
          </Menu.Item>
        </Menu>
      </div>
    </Header>
  );
};
