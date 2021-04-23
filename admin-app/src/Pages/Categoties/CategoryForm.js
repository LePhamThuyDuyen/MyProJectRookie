import React, { useState, useEffect } from "react";
import { useFormik } from "formik";
import{withRouter} from "react-router-dom";
import CategoryService from "../../Service/CategoryService";
import history from "../../Helpers/help"


const CategoryForm = ({ match }) => {
  
  const [categoryId, setCategoryId] = useState(match.params.id);
  const [Category, setCategory] = useState({});

  const formik = useFormik({
    enableReinitialize: true,
    initialValues: {
      CategoryName: Category.categoryName,
      categoryId: Category.categoryId,
    },

    onSubmit: async (values) => {
      let result = window.confirm("Confirm");
      console.log(values);
      if (result) {
        let isCreate = categoryId === undefined ? true : false;
        console.log(isCreate);
        if (isCreate) {
          await CategoryService.create(values);
          history.goBack();
        } else {
          await CategoryService.edit(categoryId, values);
          history.goBack();
        }
      }  
    },
  });
   useEffect(() => {
    async function fetchdate() {
      setCategoryId(match.params.id);
      console.log(categoryId);
      if (categoryId !== undefined) {
        await fetchCategory(categoryId);
        console.log(formik.initialValues);
      } else {
      }
    }
    fetchdate();
  }, [match.params.id]);

  const fetchCategory = async (itemId) => {
    console.log(CategoryService.get(itemId));
    setCategory(await (await CategoryService.get(itemId)).data);
  };
  console.log(Category);


    return (
      <form onSubmit={formik.handleSubmit}>
      <label htmlFor="CategoryName">Category Name</label>
      <input
        id="CategoryName"
        name="CategoryName"
        type="text"
        onChange={formik.handleChange}
        value={formik.values.CategoryName}
      />
     
      <button type="submit">Submit</button>
    </form>
  );
};

export default withRouter(CategoryForm);