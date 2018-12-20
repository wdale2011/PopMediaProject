import React from "react";
import { Card, Button, Input } from "reactstrap";
import axios from "axios";

class Register extends React.Component {
  state = {
    username: "",
    password: "",
    confirmPass: ""
  };

  inputHandler = e => {
    this.setState({ [e.target.name]: e.target.value });
  };

  register = e => {
    axios
      .post("http://localhost:50199/api/register", {
        username: this.state.username,
        password: this.state.password
      })
      .then(Response => {
        console.log(Response);
      })
      .catch(error => {
        console.log(error);
      });
  };

  cancel = e => {
    this.props.history.push("/");
  };

  render() {
    return (
      <div className="container-fluid">
        <br />
        <br />
        <br />
        <div className="row full-height-vh">
          <div className="col-12 d-flex align-items-center justify-content-center">
            <Card className="px-4 py-2 box-shadow-2 width-400">
              <h1>Register</h1>
              <br />
              <h3>Username</h3>
              <Input
                type="text"
                value={this.state.username}
                onChange={this.inputHandler}
                name="username"
                id="username"
              />
              <br />
              <h3>Password</h3>
              <Input
                type="password"
                value={this.state.password}
                onChange={this.inputHandler}
                name="password"
              />
              <br />
              {/*<h3>Confirm Password</h3>
              <Input
                type="text"
                value={this.state.confirmPass}
                onChange={this.inputHandler}
                name="confirmPass"
              />*/}
              <br />
              <Button onClick={this.register} color="primary">
                Register
              </Button>
              <br />
              <Button onClick={this.cancel}>Cancel</Button>
            </Card>
          </div>
        </div>
      </div>
    );
  }
}
export default Register;
