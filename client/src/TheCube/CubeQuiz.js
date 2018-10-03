import React from "react";
import {
  GetAll,
  GetAllQuestions,
  PostResult,
  GetResultsById,
  UpdateName,
  DeleteResult
} from "../CubeServices/cubeServices";
import {
  Button,
  Dropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem,
  Container,
  Row,
  Col
} from "reactstrap";
import "./CubeQuiz.css";

class CubeQuiz extends React.Component {
  state = {
    getAllData: [],
    getQuestions: [],
    dropdownOpen: false,
    questionShow: 1,
    result: [],
    currentAnswer: "",
    submitDisabled: true,
    UserName: "",
    editShow: false,
    showPostInput: true,
    showInputeditNameChange: false
  };

  componentDidMount() {
    GetAll().then(response => {
      this.setState({
        getAllData: response.data
      });
    });
    GetAllQuestions().then(response => {
      this.setState({
        getQuestions: response.data
      });
    });
  }

  handleAnswerTypeChange = event => {
    this.setState({
      currentAnswer: event.target.value,
      submitDisabled: false
    });
  };
  //gen lib es bing
  handleSubmit = event => {
    let current = this.state.result;
    this.setState({
      questionShow: this.state.questionShow + 1,
      result: [...current, this.state.currentAnswer],
      submitDisabled: true
    });
  };

  handleRenderResults = event => {
    GetResultsById(this.state.Id)
      .then(response =>
        this.setState({
          result: response.data[0].results,
          questionShow: 17,
          UserName: response.data[0].username,
          showPostInput: false
        })
      )
      .catch(err => {
        alert("no results found for this Id!");
      });
  };

  handleIdGetResults = event => {
    this.setState({
      Id: event.target.value
    });
  };
  handleUserNameChange = event => {
    this.setState({
      UserName: event.target.value
    });
  };
  handlePostSubmit = event => {
    let postResultString = this.state.result.join(``);
    PostResult(this.state.UserName, postResultString).then(response =>
      this.setState(
        {
          Id: response.data,
          editShow: true,
          questionShow: 17
        },
        () => {
          alert(
            "please write your Id number if you want to see your results again! Your Id number is " +
              this.state.Id
          );
        }
      )
    );
  };
  handleEditUserName = event => {
    this.setState({
      UserName: event.target.value
    });
  };
  handleEditResultsButton = event => {
    this.setState({
      showInputeditNameChange: !this.state.showInputeditNameChange
    });
  };
  handleDeleteResultsButton = event => {
    if (window.confirm("are you sure you want to delete your results?")) {
      DeleteResult(this.state.Id).then(response => {
        alert("deleted your results!"), this.props.history.push("thecube");
      });
    }
  };

  handleSaveEditResults = () => {
    UpdateName(this.state.Id, this.state.UserName).then(
      alert("updated your Username!")
    );
  };
  render() {
    const { getAllData } = this.state;
    return (
      <div style={{ backgroundColor: "black", color: "white", fontSize: 25 }}>
        <Row className="card-header justify-content-center">
          <h1> The Cube</h1>
        </Row>
        {this.state.questionShow < 18 && (
          <div>
            <div id="app">
              <div className="main rotateAnimation">
                <div className="north container" tabIndex="0">
                  <div className="cube animation">
                    <div className="blue color">
                      <div className="square top" />
                      <div className="square bottom" />
                      <div className="square left" />
                      <div className="square right" />
                      <div className="square back" />
                      <div className="square front" />
                    </div>
                  </div>
                </div>
                <div className="south container" tabIndex="1">
                  <div className="cube animation">
                    <div className="red color">
                      <div className="square top" />
                      <div className="square bottom" />
                      <div className="square left" />
                      <div className="square right" />
                      <div className="square back" />
                      <div className="square front" />
                    </div>
                  </div>
                </div>
                <div className="east container" tabIndex="2">
                  <div className="cube animation">
                    <div className="green color">
                      <div className="square top" />
                      <div className="square bottom" />
                      <div className="square left" />
                      <div className="square right" />
                      <div className="square back" />
                      <div className="square front" />
                    </div>
                  </div>
                </div>
                <div className="west container" tabIndex="3">
                  <div className="cube animation">
                    <div className="purple color">
                      <div className="square top" />
                      <div className="square bottom" />
                      <div className="square left" />
                      <div className="square right" />
                      <div className="square back" />
                      <div className="square front" />
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <Row className="card-body ">
              <Col>
                {this.state.getQuestions.map(question => {
                  if (this.state.questionShow == question.id) {
                    return (
                      <div key={question.displayOrder} className="text-center">
                        {question.type == "cube" && (
                          <div>
                            <div>
                              You are in a Desert, and you see a cube...
                            </div>
                          </div>
                        )}
                        {question.type == "ladder" && (
                          <div>
                            <div> Also in the desert, there is a ladder...</div>
                          </div>
                        )}
                        {question.type == "horse" && (
                          <div>
                            <div>
                              {" "}
                              Next, you find that there is a horse in the
                              desert...
                            </div>
                          </div>
                        )}
                        {question.type == "flowers" && (
                          <div>
                            <div>
                              {" "}
                              After that, you find some flowers in the desert...
                            </div>
                          </div>
                        )}
                        {question.type == "storm" && (
                          <div>
                            <div> Finally there is a storm approaching...</div>
                          </div>
                        )}
                        <Row className="justify-content-center fade-in">
                          {question.text}

                          <select
                            onChange={event =>
                              this.handleAnswerTypeChange(event)
                            }
                            value={this.state.currentAnswer}
                            style={{ position: "relative" }}
                          >
                            <option>choose answer</option>
                            {getAllData.map(answer => {
                              if (answer.questionId === question.id) {
                                return (
                                  <option
                                    key={"answer.id"}
                                    value={answer.result}
                                  >
                                    {answer.answer}
                                  </option>
                                );
                              }
                            })}
                          </select>
                        </Row>

                        <Row className="justify-content-center">
                          <Button
                            color="primary"
                            onClick={this.handleSubmit}
                            style={{ position: "relative" }}
                            disabled={this.state.submitDisabled}
                          >
                            {" "}
                            Submit
                          </Button>
                        </Row>
                      </div>
                    );
                  }
                })}

                {this.state.submitDisabled &&
                  this.state.questionShow < 17 && (
                    <div
                      className="text-center fade-in"
                      style={{ color: "red" }}
                    >
                      Please choose an answer!{" "}
                    </div>
                  )}
              </Col>
            </Row>
          </div>
        )}
        {this.state.questionShow !== 17 && (
          <div>
            <h3> To see a past result, type your Id here!</h3>
            <input
              type="number"
              value={this.state.Id}
              onChange={this.handleIdGetResults}
            />
            <Button onClick={this.handleRenderResults}>Search</Button>
          </div>
        )}
        {this.state.questionShow == 17 && (
          <div>
            {this.state.UserName != "" && (
              <div>
                <Row>
                  <Col>
                    <div>{this.state.UserName} </div>
                  </Col>
                </Row>
                <Row>
                  <Col>
                    <Button color="info" onClick={this.handleEditResultsButton}>
                      Edit Name?
                    </Button>
                    <Button
                      color="danger"
                      onClick={this.handleDeleteResultsButton}
                    >
                      Delete Result?
                    </Button>
                  </Col>
                </Row>
                {this.state.showInputeditNameChange && (
                  <Row>
                    <input type="text" onChange={this.handleEditUserName} />
                    <Button onClick={this.handleSaveEditResults}> Save </Button>
                  </Row>
                )}
              </div>
            )}
            <div className="">{this.state.result}</div>
            {this.state.editShow === false &&
              this.state.showPostInput && (
                <div>
                  <div>
                    Type your name and write down your Id to see your results
                    later.{" "}
                  </div>
                  <div>
                    <input
                      type="text"
                      value={this.state.UserName}
                      onChange={this.handleUserNameChange}
                    />
                    <Button onClick={this.handlePostSubmit}> Save </Button>
                  </div>
                </div>
              )}{" "}
          </div>
        )}
      </div>
    );
  }
}
export default CubeQuiz;
