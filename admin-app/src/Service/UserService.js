import httpClient from "../httpClient";

class UserService {
  pathSer = "user";

  getList() {
    return httpClient.get(this.pathSer);
  }
}
export default new UserService();