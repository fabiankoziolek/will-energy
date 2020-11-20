import { Layout } from 'antd';
import React from 'react';
import { HelmetProvider } from 'react-helmet-async';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import './App.css';
import { AppProvider } from './AppState/AppContext';
import { AppHeader } from './layout/header/AppHeader';
import { ChangeStovePage } from './modules/changeStove/ChangeStovePage';
import { WelcomePage } from './modules/welcome/WelcomePage';

const routers = {
  changeStove: '/zmien-piec',
};

const { Header, Content, Footer } = Layout;

const App = () => {
  return (
    <HelmetProvider>
      <Router>
        <AppProvider>
          <Layout className="App">
            <AppHeader routers={routers} />
            <Content className="App__Content">
              <Switch>
                <Route exact path="/">
                  <WelcomePage />
                </Route>
                <Route exact path={routers.changeStove}>
                  <ChangeStovePage />
                </Route>
              </Switch>
            </Content>
          </Layout>
        </AppProvider>
      </Router>
    </HelmetProvider>
  );
};

export default App;
