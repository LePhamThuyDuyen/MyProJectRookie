import React, { useState, useEffect } from "react";
import { Button, Table } from "reactstrap";
import CategoryService from "../../Service/CategoryService"

const ListCategory = () => {
    const [Categories, setCategories] = useState([]);
    const [itemSelected, setSelected] = React.useState(null);

    useEffect(() => {
        fetchCategory();
    }, []);

    const fetchCategory = () => {
        CategoryService.getList().then(({ data }) => setCategories(data));
    };

    const handleCreate = () => setSelected({ Name: "", TypeProductId: 0 });

    
  const handleDelete = (itemId) => {
    let result = window.confirm("Delete this item?");
    if (result) {

        CategoryService.delete(itemId).then((resp) => {
            setCategories(_removeViewItem(Categories, itemId));
      });
    }
  };

  const _removeViewItem = (lists, itemDel) =>
  lists.filter((item) => item.categoryId !== itemDel);

  
    return (
        <div>
            <br />
            <div className="text-right">
                <Button color="primary" children="New Category" onClick={() => handleCreate()} />
            </div>
            <Table>

                <thead>
                    <tr>
                        <th>STT</th>
                        <th>Category Name</th>
                    </tr>
                </thead>
                <tbody>
                    {Categories.map(function (item, i) {
                        return (
                            <tr>
                                <th scope="row">{i}</th>
                                <td>{item.categoryName}</td>
                                <td>{item.CategoryId}</td>
                                <td className="text-right">
                                  <Button //onClick={() => onEdit && onEdit(item)}
                                        color="link"
                                    >
                                        Edit
                    </Button>
                                    <Button
                                        onClick={() => handleDelete(item.categoryId)}
                                        color="link"
                                        className="text-danger"
                                    >
                                        Remove
                    </Button>
                                </td>
                            </tr>
                        );
                    })}
                </tbody>
            </Table>
        </div>
    );
};

export default ListCategory;