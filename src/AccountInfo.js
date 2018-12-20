import React from "react";
import { Input, Card, Button } from "reactstrap";
import axios from "axios";

class AccountInfo extends React.Component {
  state = {
    username: "",
    password: ""
  };

  updateAccount = () => {
    axios.put("http://localhost:50199/api/update/1", {
      username: this.state.username,
      password: this.state.password
    });
  };

  inputHandler = e => {
    this.setState({ [e.target.name]: e.target.value });
  };

  back = e => {
    this.props.history.push("/home");
  };

  render() {
    return (
      <div className="container-fluid text-center">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <h1 style={{ color: "white" }}>Account Information</h1>
        <br />
        <br />
        <div className="row full-height-vh">
          <div className="col-12 d-flex align-items-center justify-content-center">
            <br />
            <Card className="px-4 py-2 box-shadow-2 width-400">
              <h3>Username</h3>
              <Input
                placeholder="Your username"
                value={this.state.username}
                onChange={this.inputHandler}
                name="username"
              />
              <h3>Password</h3>
              <Input
                placeholder="Your password"
                value={this.state.password}
                onChange={this.inputHandler}
                name="password"
              />
              <br />
              <Button onClick={this.updateAccount} color="primary">
                Update Account Information
              </Button>
              <br />
              <Button onClick={this.back} color="primary">
                Back
              </Button>
            </Card>
          </div>
        </div>
      </div>
    );
  }
}
export default AccountInfo;
