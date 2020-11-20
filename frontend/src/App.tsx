import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import classNames from 'classnames';
import { HelmetProvider } from 'react-helmet-async';
import './App.css';
import { WelcomePage } from './modules/welcome/WelcomePage';

const App = () => {
  return (
    <HelmetProvider>
      <Router>
        <div id="App" className={classNames('App')}>
          <Switch>
            <Route exact path="/">
              <WelcomePage />
            </Route>
          </Switch>
        </div>
      </Router>
    </HelmetProvider>
  );
};

export default App;
