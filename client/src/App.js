import React, { Component } from "react";
import { Route } from "react-router-dom";
import CubeQuiz from "./TheCube/CubeQuiz";

class App extends Component {
  render() {
    return (
      <div>
        <Route path="/TheCube" render={props => <CubeQuiz {...props} />} />
      </div>
    );
  }
}

export default App;
