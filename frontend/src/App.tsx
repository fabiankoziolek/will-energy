import { Layout } from 'antd';
import React from 'react';
import { HelmetProvider } from 'react-helmet-async';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import './App.css';
import { AppProvider } from './AppState/AppContext';
import { AppFooter } from './layout/footer/AppFooter';
import { AppHeader } from './layout/header/AppHeader';
import { ChangeFurnacePage } from './modules/changeFurnace/ChangeFurnacePage';
import { FillFormPage } from './modules/fillForm/FillFormPage';
import { WelcomePage } from './modules/welcome/WelcomePage';

const routes = {
  changeFurnace: '/zmien-piec',
  fillForm: '/dofinansowanie',
};

const { Content } = Layout;

const App = () => {
  return (
    <HelmetProvider>
      <Router>
        <AppProvider>
          <Layout className="App">
            <AppHeader routes={routes} />
            <Content className="App__content">
              <Switch>
                <Route exact path="/">
                  <WelcomePage />
                </Route>
                <Route exact path={routes.changeFurnace}>
                  <ChangeFurnacePage />
                </Route>
                <Route exact path={routes.fillForm}>
                  <FillFormPage />
                </Route>
              </Switch>
            </Content>
            <AppFooter />
          </Layout>
        </AppProvider>
      </Router>
    </HelmetProvider>
  );
};

export default App;
