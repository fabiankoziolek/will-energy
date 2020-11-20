import * as React from 'react';
import { Layout, Menu } from 'antd';
import { Link, useLocation } from 'react-router-dom';
import './AppHeader.css';

const { Header } = Layout;

interface IAppHeaderProps {
  routes: { changeFurnace: string; fillForm: string };
}

export const AppHeader: React.FC<IAppHeaderProps> = (props) => {
  const { routes } = props;
  const location = useLocation();
  return (
    <Header className="AppHeader">
      <Menu theme="dark" mode="horizontal" defaultSelectedKeys={[location.pathname]}>
        <Menu.Item key={routes.changeFurnace}>
          <Link to={routes.changeFurnace}>Zmień piec</Link>
        </Menu.Item>
        <Menu.Item key={routes.fillForm}>
          <Link to={routes.fillForm}>Dofinansowanie</Link>
        </Menu.Item>
      </Menu>
    </Header>
  );
};
