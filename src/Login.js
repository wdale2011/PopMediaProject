import React from "react";
import { Card, Button, Input } from "reactstrap";
import axios from "axios";
import "./HomePage.css";
import {
  NotificationContainer,
  NotificationManager
} from "react-notifications";
import "react-notifications/lib/notifications.css";

class Login extends React.Component {
  state = {
    username: "",
    password: "",
    error: false,
    errorMessage: ""
  };

  inputHandler = e => {
    this.setState({ [e.target.name]: e.target.value });
  };
  submit = e => {
    this.props.history.push("/home");
  };
  register = e => {
    this.props.history.push("/register");
  };
  login = e => {
    axios
      .get(`/api/login/${this.state.username}/${this.state.password}`)
      .then(Response => {
        this.submit();
        console.log(Response);
      })
      .catch(error => {
        this.setState({
          errorMessage: "Invalid login credentials",
          error: true
        });
        console.log(error);
      });
  };

  render() {
    return (
      <div className="container-fluid">
        <br />
        <br />
        <br />
        <br />
        <div className="row full-height-vh">
          <div className="col-12 d-flex align-items-center justify-content-center">
            <br />
            <Card className="px-4 py-2 box-shadow-2 width-400">
              <h1>Login</h1>
              <br />
              <h2>Username</h2>
              <Input
                type="text"
                value={this.state.login}
                onChange={this.inputHandler}
                name="username"
                invalid={this.state.error}
                onBlur={() => this.setState({ error: false })}
              />
              <h2>Password</h2>
              <Input
                type="password"
                value={this.state.password}
                onChange={this.inputHandler}
                name="password"
                invalid={this.state.error}
                onBlur={() => this.setState({ error: false })}
              />
              <br />
              <span style={{ color: "red" }} className="text-center">
                {this.state.errorMessage ? this.state.errorMessage : null}
              </span>
              <br />
              <Button onClick={this.login} color="primary">
                Login
              </Button>
              <br />
              <Button onClick={this.register} color="link">
                Click here to register if you don't have an account
              </Button>
            </Card>
          </div>
        </div>
      </div>
    );
  }
}
export default Login;
