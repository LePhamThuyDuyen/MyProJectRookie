import React, {Component} from 'react';
import { Link } from 'react-router-dom';

export default class Navbar extends Component {
    render(){
        return (
            <aside className="main-sidebar sidebar-dark-primary elevation-4">
    {/* <!-- Brand Logo --> */}
    <a href="index3.html" className="brand-link">
      <img src="img/logo.png" alt="AdminLTE Logo" className="brand-image img-circle elevation-3" style={{opacity: .8}}/>
      <span className="brand-text font-weight-light">Admin</span>
    </a>

    
    <div className="sidebar">
      {/* <!-- Sidebar user panel (optional) --> */}
      <div className="user-panel mt-3 pb-3 mb-3 d-flex">
        <div className="image">
          <img src="img/logo.png" className="img-circle elevation-2" alt="User Image"/>
        </div>
        <div className="info">
          <a href="#" className="d-block"></a>
        </div>  
      </div>

      {/* <!-- SidebarSearch Form --> */}
      <div className="form-inline">
        <div className="input-group" data-widget="sidebar-search">
          <input className="form-control form-control-sidebar" type="search" placeholder="Search" aria-label="Search"/>
          <div className="input-group-append">
            <button className="btn btn-sidebar">
              <i className="fas fa-search fa-fw"></i>
            </button>
          </div>
        </div>
      </div>

      <nav className="mt-2">
        <ul className="nav nav-pills nav-sidebar flex-column" data-widget="treeview" role="menu" data-accordion="false">
            <li className="nav-item">
            <a href="/category" className="nav-link">
            <i className="fas fa-list-ol"></i>
              <p>
              &nbsp;
            
              
              Category
               
              </p>
            </a>
          </li>
          <li className="nav-item">
            <a href="/product" className="nav-link">
            <i className="fas fa-carrot"></i>
              <p>
              &nbsp;
                Product
              </p>
            </a>
          </li>
          <li className="nav-item">
            <a href="/user" className="nav-link">
            <i className="fas fa-star"></i>
              <p>
              &nbsp;
               User
              </p>
            </a>
          </li>
        </ul>
      </nav>
    </div>
  </aside>
        )
    }
}