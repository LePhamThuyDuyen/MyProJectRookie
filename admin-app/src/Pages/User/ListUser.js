import React, { useState, useEffect } from 'react'
import { Table } from 'reactstrap';
import UserSevice from "../../Service/UserService"



const ListUser = () => {
    const [Users, setUsers] = useState([]);

    useEffect(() => {
        fetchUser();
    }, []);

    const fetchUser = () => {
        UserSevice.getList().then(({ data }) => setUsers(data));
    };

        
    return (
        <div>
            <Table>

                <thead>
                    <tr>
                        <th>STT</th>
                        <th>User Name</th>
                        <th>Email</th>
                        <th>Phone</th>
                        <th>EmailConfirmed</th>
                    </tr>
                </thead>
                <tbody>
                    {Users.map(function (item, i) {
                        return (
                            <tr>
                                <th scope="row">{i}</th>
                                <td>{item.userName}</td>
                                <td>{item.email }</td>
                                <td>{item.phoneNumber }</td>
                                <td>{item.emailConfirmed }</td>                               
                            </tr>
                        );
                    })}
                </tbody>
            </Table>
        </div>
    );
};

export default ListUser;