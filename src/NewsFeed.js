import React from "react";
import { Card } from "reactstrap";
import NewsCard from "./NewsCard";
import axios from "axios";

class NewsFeed extends React.Component {
  state = {
    newsFeed: {}
  };

  componentDidMount = () => {
    axios
      .get("http://localhost:50199/api/newsFeed")
      .then(Response => {
        console.log(Response);
        this.setState({ newsFeed: Response.data });
      })
      .catch(error => {
        console.log(error);
      });
  };
  render() {
    return (
      <div className="text-center">
        <Card>
          <h2>Today's News Feed</h2>
          <NewsCard newsFeed={this.state.newsFeed} />
        </Card>
      </div>
    );
  }
}
export default NewsFeed;
