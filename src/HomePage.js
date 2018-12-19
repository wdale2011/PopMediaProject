import React from "react";
import { Card } from "reactstrap";
import NewsFeed from "./NewsFeed";

class HomePage extends React.Component {
  render() {
    return (
      <div>
        <div className="container-fluid">
          <Card className="box-shadow-2">
            <div className="text-center">
              <h1>Welcome to PoptheBubbleMedia!</h1>
              <h2>
                Your tool to popping your media bubble and broadening your
                perspective
              </h2>
            </div>
          </Card>
          <NewsFeed />
        </div>
      </div>
    );
  }
}
export default HomePage;
