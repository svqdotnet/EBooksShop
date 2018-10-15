import React, { Component } from 'react';
import '../login/Login.css';
import axios from 'axios';
import Input from '../input/Input';

class Main extends Component {
  constructor(props) {
    super(props);
    this.state = {
      errorMessage: "",
      erorMessageJWT: "",
      value: 0
    }
    this.clickHandlerById = this.clickHandlerById.bind(this);
    this.clickHandler = this.clickHandler.bind(this);
    this.setValue = this.setValue.bind(this);
  }

  setValue(value) {
    this.setState({ value: value });
  }

  clickHandlerById() {

    axios.get("http://localhost:5000/api/values/" + this.state.value).then((response) => {
      if (response != null && response.data != null) {
        this.setState({ errorMessage: response.data });
      }
    }).catch((error) => {
      if (error != null && error.message != null) {
        this.setState({ errorMessage: error.message });
      }
    });
  }

  clickHandler() {
    axios.get("http://localhost:5000/api/values").then((response) => {
      if (response != null && response.data != null) {
        let message = response.data[0] + ' and ' + response.data[1];
        this.setState({ errorMessageJWT: message });
      }
    }).catch((error) => {
      if (error != null && error.message != null) {
        this.setState({ errorMessageJWT: error.message });
      }
    });
  }

  render() {
    return (
      <div>
        <div className="Login-form">
          <Input id="value" labelName="Value: " inputType="number" parentFunction={this.setValue} />
          <button onClick={this.clickHandlerById}>Get Values By ID</button>
          <p className="error">{this.state.errorMessage}</p>
        </div>
        <div className="Login-form">
          <button onClick={this.clickHandler}>Get Values with JWT</button>
          <p className="error">{this.state.errorMessageJWT}</p>
        </div>
      </div>
    );
  }
}


export default Main;