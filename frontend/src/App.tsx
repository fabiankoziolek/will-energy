import { Button, Layout } from 'antd';
import React from 'react';
import { HelmetProvider } from 'react-helmet-async';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import './App.css';
import { AppProvider } from './AppState/AppContext';
import { AppFooter } from './layout/footer/AppFooter';
import { AppHeader } from './layout/header/AppHeader';
import { ApplicationWizard } from './modules/applicationWizard/ApplicationWizard';
import { ChangeFurnacePage } from './modules/changeFurnace/ChangeFurnacePage';
import { FillFormPage } from './modules/fillForm/FillFormPage';
import { WelcomePage } from './modules/welcome/WelcomePage';
import * as Icon from 'react-feather';
import { useHistory } from 'react-router-dom';
import { routes } from './routes';

const { Content, Header } = Layout;

const BackContextWrapper = (props: { children: React.ReactNode; backTo: string }) => {
  const history = useHistory();
  console.log(history);
  return (
    <>
      <Header className="AppHeader">
        <Button onClick={() => history.push(props.backTo)} icon={<Icon.ArrowLeft />} type="text">
          Wróć na poprzednią stronę
        </Button>
      </Header>
      <Content className="App__content">{props.children}</Content>
    </>
  );
};

const App = () => {
  return (
    <HelmetProvider>
      <Router>
        <AppProvider>
          <Layout className="App">
            <Switch>
              <Route exact path={routes.applicationWizard}>
                <BackContextWrapper backTo={routes.fillForm}>
                  <ApplicationWizard />
                </BackContextWrapper>
              </Route>
              <Route exact path={routes.privacyPolicy}>
                <BackContextWrapper backTo={'/'}>Polityka</BackContextWrapper>
              </Route>
              <Route path="/">
                <AppHeader />
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
              </Route>
            </Switch>
          </Layout>
        </AppProvider>
      </Router>
    </HelmetProvider>
  );
};

export default App;
