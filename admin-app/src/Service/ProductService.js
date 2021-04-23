import httpClient from "../httpClient";

class ProductService {
  pathSer = "Product";

  getList() {
    return httpClient.get(this.pathSer);
  }

  get(id){
    return httpClient.get(this.pathSer+"/"+id);
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
  export default new ProductService();