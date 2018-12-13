import React from "react";
import { BrowserRouter as Router, Route } from "react-router-dom";
import "./App.css";
import HomePage from "./HomePage";

class App extends React.Component {
  render() {
    return (
      <Router>
        <div>
          <Route path="/" component={HomePage} />
        </div>
      </Router>
    );
  }
}

export default App;
