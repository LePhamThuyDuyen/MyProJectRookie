import React, { useState, useEffect } from "react";
import { Formik, useFormik } from "formik";
import { withRouter } from "react-router-dom";
import ProductService from "../../Service/ProductService";
import history from "../../Helpers/help"

const ProductForm = ({ match }) => {

  const [productId, setProductId] = useState(match.params.id);
  const [Product, setProduct] = useState({});
  const [image, setImage] = useState("");
  const [isCreate, setIsCreate] = useState(match.params.id === undefined ? true : false);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    async function fetchdata() {
      setProductId(match.params.id);
      console.log(productId);
      if (productId !== undefined) {
        await fetchProduct(productId);
      }

    }
    
    fetchdata();
  }, [match.params.id]);
  
  console.log("is creazzzz P", Product);
  const formik = useFormik({
    enableReinitialize: true,
    initialValues: {
      ProductName: Product.productName,
      Price: Product.price,
      Description: Product.description,
      CategoryID: Product.categoryID,
      ImageRequest: Product.image,
    }
    ,
    onSubmit: async (values) => {
      let result = window.confirm("Are you sure?");
      console.log("values ne",values);
      console.log(image);
      if (result) {
        if (isCreate) {
          await ProductService.create(changeFormikValuestoFormData(values));
          history.goBack();
        } else {
          console.log("values edit", values);
          await ProductService.edit(productId, changeFormikValuestoFormData(values));
          history.goBack();
        }
      }
    },
  });


  const fetchProduct = async (itemId) => {
    console.log(ProductService.get(itemId));
    setProduct(await (await ProductService.get(itemId)).data);
  };

  const uploadImage = async (e) => {
    const files = e.target.files;
    const data = new FormData();
    data.append("file", files[0]);
    data.append("upload_preset", "leduyen");
    setLoading(true);
    console.log("acb",loading);
    const res = await fetch(
      " https://api.cloudinary.com/v1_1/dusq8k6rj/image/upload",
      {
        method: "POST",
        body: data,
      }
    );
    const file = await res.json();
    setImage(file.secure_url);
    setLoading(false);
    console.log("conmeo",image);
    console.log("conmeo2",file.secure_url); 
    if (isCreate) {
      formik.values.ImageRequest =file.secure_url;
    }
    else {
      formik.values.ImageRequest = file.secure_url;
    }
  };

  const changeFormikValuestoFormData = (valueForm) => {
    const formSubmitDataLocal = new FormData();
    formSubmitDataLocal.append('ProductName', valueForm.ProductName);
    formSubmitDataLocal.append('price', valueForm.Price);
    formSubmitDataLocal.append('description', valueForm.Description);
    formSubmitDataLocal.append('categoryId', valueForm.CategoryID);
    formSubmitDataLocal.append('ImageRequest', valueForm.ImageRequest);
    console.log(formSubmitDataLocal);
    return formSubmitDataLocal;
  }

  console.log("run zzzz", formik.initialValues);

  return (
    <div class="content-wrapper">
      <form onSubmit={formik.handleSubmit}>

        <div className="form-group">
          <label htmlFor="ProductName">Product Name</label>
          <input
            id="ProductName"
            name="ProductName"
            className="form-control"
            type="textarea"
            {...formik.getFieldProps('ProductName')}
            defaultvalue={formik.values.ProductName}
          />
        </div>
        <div className="form-group row">
          <div className="form-group col">
            <label htmlFor="Price">Price</label>
            <input
              id="Price"
              name="Price"
              type="number"
              {...formik.getFieldProps('Price')}
              defaultvalue={formik.values.price}
            />
          </div>

          <div className="form-group col">
            <label htmlFor="CategoryID">Category Id</label>
            <input
              id="CategoryID"
              name="CategoryID"
              type="number"
              {...formik.getFieldProps('CategoryID')}
              defaultvalue={formik.values.categoryId}
            />
          </div>
        </div>
        <div className="form-group">
          <label htmlFor="Description">Description</label>
          <input
            id="Description"
            name="Description"
            type="textarea"
            className="form-control"
            {...formik.getFieldProps('Description')}
            defaultvalue={formik.values.description}
          />
        </div>
        <div className="form-group">
          <label htmlFor="ImageRequest">Upload Image</label>
          <input
            type="file"
            id="ImageRequest"
            name="ImageRequest"
            placeholder="Upload an image"
            onChange={uploadImage}
            style={{ display: "block" }}
          />
          {
            loading ? (
              <h3>Loading...</h3>
            ) : (
              <img src={image} style={{ width: "100px" }} alt="product-image" />
            )
          }
        </div>
        <button type="submit">Submit</button>

      </form>
    </div>
  );
};

export default withRouter(ProductForm);

