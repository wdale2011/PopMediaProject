import React from "react";
import { Card } from "reactstrap";
import NewsCard from "./NewsCard";

class NewsFeed extends React.Component {
  render() {
    return (
      <div className="text-center">
        <Card>
          <h2>Today's News Feed</h2>
          <NewsCard />
        </Card>
      </div>
    );
  }
}
export default NewsFeed;
