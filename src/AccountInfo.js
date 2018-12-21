import React from "react";
import { Input, Card, Button } from "reactstrap";
import axios from "axios";
import { connect } from "react-redux";

class AccountInfo extends React.Component {
  state = {
    username: "",
    password: "",
    updated: false
  };

  componentDidMount = () => {
    axios
      .get(`http://localhost:50199/api/account/${this.props.user}`)
      .then(Response => {
        console.log(Response.data);
        this.setState({
          username: Response.data.Username,
          password: Response.data.Password
        });
      })
      .catch(error => {
        console.log(error);
      });
  };

  updateAccount = () => {
    axios
      .put("http://localhost:50199/api/update", {
        id: this.props.user,
        username: this.state.username,
        password: this.state.password
      })
      .then(Response => {
        this.setState({ updated: true });
        console.log(Response);
      })
      .catch(error => {
        console.log(error);
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
              <span style={{ color: "green" }}>
                {this.state.updated ? "Account updated!" : null}
              </span>
              <br />
              <Button onClick={this.updateAccount} color="success">
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
function mapStateToProps(state) {
  return {
    user: state.user
  };
}
export default connect(mapStateToProps)(AccountInfo);
