import React from "react";
import { Card } from "reactstrap";
import newsPaperImage from "./images/NewsPaper.jpg";

class NewsCard extends React.Component {
  state = {
    newsFeed: this.props.newsFeed
  };

  render() {
    return (
      <div>
        <div className="col-12">
          <Card className="box-shadow-10">
            <br />
            <h3>News Title:</h3>
            <span>
              <img src={newsPaperImage} alt="newsPaperImage" />
            </span>
            <br />
            <h4>
              News Link :<span />
            </h4>
            <h4>
              News Source :
              <span />
            </h4>
          </Card>
          <br />
        </div>
      </div>
    );
  }
}
export default NewsCard;
