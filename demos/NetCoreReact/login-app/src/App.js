import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import Login from './components/login/Login';
import Main from './components/main/Main';
import { BrowserRouter as Router, Route } from 'react-router-dom';

class App extends Component {

  render() {
    return (
      <div className="App">
        <Router>
          <header className="App-header">
            <img src={logo} className="App-logo" alt="logo" />
            <Route exact path="/" component={Login} />
            <Route path="/mainpage" component={Main} />
          </header>
        </Router>
      </div>
    );
  }
}

export default App;
