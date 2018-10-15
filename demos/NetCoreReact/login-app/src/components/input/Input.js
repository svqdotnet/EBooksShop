import React, { Component } from 'react';

class Input extends Component {
    constructor(props) {
        super(props);
        this.state = {
            inputVal: ""
        }
        this.changeHandler = this.changeHandler.bind(this);
    }

    changeHandler(e) {
        this.props.parentFunction(e.target.value);
    }

    render() {
        return (
            <div>
                <label>{this.props.labelName}</label>
                <input type={this.props.inputType} id={this.props.id} onChange={this.changeHandler} />
            </div>
        )
    }
}
export default Input;