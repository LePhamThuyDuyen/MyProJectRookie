import httpClient from "../httpClient";

class CategoryService {
  pathSer = "api/Category";

  getList() {
    return httpClient.get(this.pathSer);
  }
  edit(id, objectEdit) {
    return httpClient.put(this.pathSer + "/" + id, objectEdit);
  }

  delete(id) {
    return httpClient.delete(this.pathSer + "/" + id);  
  }

  create(objectNew) {
    return httpClient.post(this.pathSer, objectNew);
  }
}
  export default new CategoryService();