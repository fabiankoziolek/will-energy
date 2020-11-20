import * as React from 'react';
import { Layout, Menu } from 'antd';
import { Link, useLocation } from 'react-router-dom';
import './AppHeader.css';

const { Header } = Layout;

interface IAppHeaderProps {
  routers: { changeStove: string };
}

export const AppHeader: React.FC<IAppHeaderProps> = (props) => {
  const { routers } = props;
  const location = useLocation();
  return (
    <Header className="AppHeader">
      <Menu theme="dark" mode="horizontal" defaultSelectedKeys={[location.pathname]}>
        <Menu.Item key="1">Jakość powietrza</Menu.Item>
        <Menu.Item key={routers.changeStove}>
          <Link to={routers.changeStove}>Zmień piec</Link>
        </Menu.Item>
        <Menu.Item key="3">Dofinansowanie</Menu.Item>
      </Menu>
    </Header>
  );
};
