import React from "react";
import { Card } from "reactstrap";
import newsPaperImage from "./images/NewsPaper.jpg";

class NewsCard extends React.Component {
  render() {
    return (
      <div>
        <div className="col-12">
          <Card className="box-shadow-10">
            <span src="https://news.google.com/news/rss/headlines/section/topic/POLITICS?ned=us&hl=en&gl=US" />
            <br />
            <h3>Something Happened!</h3>
            <span>
              <img src={newsPaperImage} alt="newsPaperImage" />
            </span>
            <br />
            <h4>
              News Source : <span>Placeholder News</span>
            </h4>
            <h4>
              Source Leans : <span>Political Affiliation</span>
            </h4>
            <h4>
              Credibility : <span>Credibility Rating</span>
            </h4>
          </Card>
          <Card className="box-shadow-10">
            <br />
            <h3>Something Happened!</h3>
            <span>
              <img src={newsPaperImage} alt="newsPaperImage" />
            </span>
            <br />
            <h4>
              News Source : <span>Placeholder News</span>
            </h4>
            <h4>
              Source Leans : <span>Political Affiliation</span>
            </h4>
            <h4>
              Credibility : <span>Credibility Rating</span>
            </h4>
          </Card>
          <Card className="box-shadow-10">
            <br />
            <h3>Something Happened!</h3>
            <span>
              <img src={newsPaperImage} alt="newsPaperImage" />
            </span>
            <br />
            <h4>
              News Source : <span>Placeholder News</span>
            </h4>
            <h4>
              Source Leans : <span>Political Affiliation</span>
            </h4>
            <h4>
              Credibility : <span>Credibility Rating</span>
            </h4>
          </Card>
          <Card className="box-shadow-10">
            <br />
            <h3>Something Happened!</h3>
            <span>
              <img src={newsPaperImage} alt="newsPaperImage" />
            </span>
            <br />
            <h4>
              News Source : <span>Placeholder News</span>
            </h4>
            <h4>
              Source Leans : <span>Political Affiliation</span>
            </h4>
            <h4>
              Credibility : <span>Credibility Rating</span>
            </h4>
          </Card>
          <br />
        </div>
      </div>
    );
  }
}
export default NewsCard;
