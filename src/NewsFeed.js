import React from "react";
import { Button, Card } from "reactstrap";
import NewsCard from "./NewsCard";
import axios from "axios";
import fireSmall from "./images/fireSmall.png";

class NewsFeed extends React.Component {
  state = {
    newsFeed: [],
    runGetAll: false
  };

  componentDidMount = () => {
    axios
      .get("http://localhost:50199/api/newsFeed/scrapper")
      .then(Response => {
        console.log(Response);
        this.setState({ runGetAll: true });
        this.getFirstPage(true);
      })
      .catch(error => {
        console.log(error);
      });
  };

  getFirstPage = pass => {
    if (pass === true) {
      axios
        .get("http://localhost:50199/api/newsFeed")
        .then(Response => {
          this.setState({ newsFeed: Response.data });
        })
        .catch(error => {
          console.log(error);
        });
    }
  };

  burnThePapers = e => {
    axios
      .delete("http://localhost:50199/api/delete")
      .then(Response => {
        this.getFirstPage(true);
        console.log(Response);
      })
      .catch(error => {
        console.log(error);
      });
  };

  render() {
    return (
      <div className="col-12">
        <div className="text-center">
          {this.state.newsFeed !== undefined ? (
            <Card style={{ backgroundColor: "Ivory" }}>
              <br />
              <h2>Today's News Feed</h2>
              <br />
              <br />
              <div>
                {this.state.newsFeed.map((news, index) => (
                  <div key={index}>
                    <div>
                      <NewsCard
                        title={news.Name}
                        image={news.Image}
                        link={news.Link}
                        site={news.Site}
                      />
                    </div>
                  </div>
                ))}
              </div>
              <Button color="danger" onClick={() => this.burnThePapers()}>
                <img src={fireSmall} height={50} width={50} alt="fire" />
                <img src={fireSmall} height={50} width={50} alt="fire" />
                <img src={fireSmall} height={50} width={50} alt="fire" />
                <img src={fireSmall} height={50} width={50} alt="fire" />
                <img src={fireSmall} height={50} width={50} alt="fire" />
                <img src={fireSmall} height={50} width={50} alt="fire" />
                <img src={fireSmall} height={50} width={50} alt="fire" />
                <img src={fireSmall} height={50} width={50} alt="fire" />
                <img src={fireSmall} height={50} width={50} alt="fire" />
                <img src={fireSmall} height={50} width={50} alt="fire" />
                <span style={{ fontSize: 20 }}>Burn all the newspapers!</span>
                <img src={fireSmall} height={50} width={50} alt="fire" />
                <img src={fireSmall} height={50} width={50} alt="fire" />
                <img src={fireSmall} height={50} width={50} alt="fire" />
                <img src={fireSmall} height={50} width={50} alt="fire" />
                <img src={fireSmall} height={50} width={50} alt="fire" />
                <img src={fireSmall} height={50} width={50} alt="fire" />
                <img src={fireSmall} height={50} width={50} alt="fire" />
                <img src={fireSmall} height={50} width={50} alt="fire" />
                <img src={fireSmall} height={50} width={50} alt="fire" />
              </Button>
              <br />
              <br />
            </Card>
          ) : null}
        </div>
      </div>
    );
  }
}
export default NewsFeed;
