import React, { useState, useEffect } from "react";
import { Button, Table } from "reactstrap";
import { Link } from "react-router-dom";
import ProductService from '../../Service/ProductService';
import ProductImage from "../../components/ProductImage";

const ListProduct = () => {
    const [products, setProduct] = useState([]);
    const [itemSelected, setSelected] = React.useState(null);

    useEffect(() => {
        fetchProduct();
    }, []);

    const fetchProduct = () => {
        ProductService.getList().then(({ data }) => setProduct(data));
    };

    const handleCreate = () => setSelected({ Name: "", TypeProductId: 0 });


    const handleDelete = (itemId) => {
        let result = window.confirm("Delete this item?");
        if (result) {

            ProductService.delete(itemId).then((resp) => {
                setProduct(_removeViewItem(products, itemId));
            });
        }
    };

    const _removeViewItem = (lists, itemDel) =>
        lists.filter((item) => item.productID !== itemDel);
        
    return (
        <div>
            <br />
            <div className="text-right">
            <Link to={`/createcategory/`} >
            <Button  color="link"className="text-success">
                Create
            </Button>
            </Link>
            </div>
            <Table>

                <thead>
                    <tr>
                        <th>STT</th>
                        <th>Product Name</th>
                        <th>Price</th>
                        <th>Image</th>
                        <th>Category ID</th>
                    </tr>
                </thead>
                <tbody>
                    {products.map(function (item, i) {
                        return (
                            <tr key={i}>
                                <th scope="row">{i}</th>
                                <td>{item.productName}</td>                              
                                <td>{item.price}</td>
                                <td>{item.categoryName}</td>
                               <td><ProductImage src={item.image} text={item.productName}/></td> 
                                <td className="text-right">
                                <Link to={`/Editcategory/${item.productID}`} >
                                    <Button
                                        color="link"
                                    >
                                        Edit
                    </Button>
                    </Link>
                                    <Button
                                        onClick={() => handleDelete(item.productID)}
                                        color="link"
                                        className="text-danger"  >
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

export default ListProduct;
