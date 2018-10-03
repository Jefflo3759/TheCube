import axios from "axios";

export function GetAll() {
  return axios.get("/api/thecube");
}

export function GetAllQuestions() {
  return axios.get("/api/thecube/questions");
}

export function PostResult(UserName, Results) {
  return axios.post("/api/thecube/results", {
    UserName,
    Results
  });
}

export function UpdateName(Id, Username) {
  return axios.put(`/api/thecube/results/` + Id, {
    Id,
    Username
  });
}

export function GetResultsById(Id) {
  return axios.get(`/api/thecube/results/` + Id, {
    Id
  });
}

export function DeleteResult(Id) {
  return axios.delete(`/api/thecube/results/` + Id, {
    Id
  });
}
