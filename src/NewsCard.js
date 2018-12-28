import React from "react";
import { Card } from "reactstrap";
import newsIcon from "./images/newsIcon.jpg";
import "./HomePage.css";

class NewsCard extends React.Component {
  websiteRedirect = url => {
    window.location = url;
  };

  render() {
    return (
      <div>
        <div className="col-12">
          <Card
            className="box-shadow-10 hover"
            onClick={() => this.websiteRedirect(this.props.link)}
          >
            <br />
            <h3>Headline : {this.props.title}</h3>
            <span>
              <img
                src={this.props.image}
                alt="newsPaperImage"
                height={200}
                width={200}
              />
            </span>
            <br />
            <h4>
              News Source : {this.props.site}
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
