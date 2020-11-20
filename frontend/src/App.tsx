import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import classNames from 'classnames';
import { HelmetProvider } from 'react-helmet-async';
import './App.css';
import { WelcomePage } from './modules/welcome/WelcomePage';
import { AppProvider } from './AppState/AppContext';
import { Test } from './modules/test/TestPage';

const App = () => {
  return (
    <HelmetProvider>
      <Router>
        <div id="App" className={classNames('App')}>
          <AppProvider>
            <Switch>
              <Route exact path="/">
                <WelcomePage />
              </Route>
              <Route exact path="/test">
                <Test />
              </Route>
            </Switch>
          </AppProvider>
        </div>
      </Router>
    </HelmetProvider>
  );
};

export default App;
