import React from "react";
import { Card } from "reactstrap";
import NewsCard from "./NewsCard";
import axios from "axios";

class NewsFeed extends React.Component {
  state = {
    newsFeed: []
  };

  componentDidMount = () => {
    axios
      .get("http://localhost:50199/api/newsFeed")
      .then(Response => {
        console.log(Response.data);
        this.setState({ newsFeed: Response.data });
      })
      .catch(error => {
        console.log(error);
      });
  };
  render() {
    return (
      <div className="text-center">
        {this.state.newsFeed !== undefined ? (
          <Card>
            <h2>Today's News Feed</h2>
            <div>
              {this.state.newsFeed.map((news, index) => (
                <div key={index}>
                  <div>
                    <NewsCard
                      title={news.Name}
                      link={news.Link}
                      site={news.Site}
                    />
                  </div>
                </div>
              ))}
            </div>
          </Card>
        ) : null}
      </div>
    );
  }
}
export default NewsFeed;
