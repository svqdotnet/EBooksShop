import React, { Component } from 'react';
import './Login.css';
import axios from 'axios';
import { withRouter } from 'react-router-dom';
import Input from '../input/Input';

class Login extends Component {
  constructor(props) {
    super(props);
    this.state = {
      username: "",
      password: "",
      errorMessage: ""
    }
    this.clickHandler = this.clickHandler.bind(this);
    this.setUsername = this.setUsername.bind(this);
    this.setPassword = this.setPassword.bind(this);
  }

  setUsername(username) {
    this.setState({ username: username });
  }

  setPassword(password) {
    this.setState({ password: password });
  }

  clickHandler() {
    
    this.setState({ errorMessage: "" });

    let postData = {
      username: this.state.username,
      password: this.state.password
    }

    axios.post("http://localhost:5000/api/user/authenticate", postData).then((response) => {
      if (response != null && response.data != null) {
        this.props.history.push('/mainPage');
      }
    }).catch((error) => {
      if (error != null && error.message != null) {
        this.setState({ errorMessage: error.message });
      }
    });
  }

  render() {
    return (
      <div className="Login-form">
        <Input id="username" labelName="Username: " inputType="text" parentFunction={this.setUsername} />
        <Input id="password" labelName="Password: " inputType="password" parentFunction={this.setPassword} />
        <button onClick={this.clickHandler}>Login</button>
        <p className="error">{this.state.errorMessage}</p>
      </div>
    );
  }
}

export default withRouter(Login);