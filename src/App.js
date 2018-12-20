import React from "react";
import { BrowserRouter as Router, Route } from "react-router-dom";
import "./App.css";
import HomePage from "./HomePage";
import Login from "./Login";
import Register from "./Register";
import AccountInfo from "./AccountInfo";

class App extends React.Component {
  render() {
    return (
      <Router>
        <div>
          <Route exact path="/" component={Login} />
          <Route exact path="/register" component={Register} />
          <Route exact path="/home" component={HomePage} />
          <Route exact path="/accountInfo" component={AccountInfo} />
        </div>
      </Router>
    );
  }
}

export default App;
