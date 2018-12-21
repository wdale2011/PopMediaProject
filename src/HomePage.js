import React from "react";
import { Card, Button, FormGroup } from "reactstrap";
import NewsFeed from "./NewsFeed";
import "./HomePage.css";

class HomePage extends React.Component {
  logout = () => {
    this.props.history.push("/");
  };

  register = () => {
    this.props.history.push("/register");
  };

  accountInfo = () => {
    this.props.history.push("/accountInfo");
  };

  render() {
    return (
      <div>
        <div className="container-fluid background">
          <div className="col-12">
            <br />
            <FormGroup className="text-center">
              <Button
                onClick={this.logout}
                size="lg"
                color="danger"
                className="box-shadow"
              >
                Logout
              </Button>
              {"  "}
              {"  "}
              <Button
                onClick={this.accountInfo}
                size="lg"
                color="primary"
                className="box-shadow"
              >
                Account Information
              </Button>
            </FormGroup>
          </div>
          <div className="text-center" style={{ color: "ivory" }}>
            <h1>Welcome to PoptheBubbleMedia!</h1>
            <h2>
              Your tool for popping your media bubble and broadening your
              perspective
            </h2>
          </div>
          <br />
          <NewsFeed />
          <br />
          <br />
        </div>
      </div>
    );
  }
}
export default HomePage;
