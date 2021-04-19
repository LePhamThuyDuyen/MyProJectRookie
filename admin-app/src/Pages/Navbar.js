import React, {Component} from 'react';

export default class Navbar extends Component {
    render(){
        return (
            <aside class="main-sidebar sidebar-dark-primary elevation-4">
    {/* <!-- Brand Logo --> */}
    <a href="index3.html" class="brand-link">
      <img src="img/logo.png" alt="AdminLTE Logo" class="brand-image img-circle elevation-3" style={{opacity: .8}}/>
      <span className="brand-text font-weight-light">Admin</span>
    </a>

    
    <div class="sidebar">
      {/* <!-- Sidebar user panel (optional) --> */}
      <div class="user-panel mt-3 pb-3 mb-3 d-flex">
        <div class="image">
          <img src="img/logo.png" class="img-circle elevation-2" alt="User Image"/>
        </div>
        <div class="info">
          <a href="#" class="d-block"></a>
        </div>  
      </div>

      {/* <!-- SidebarSearch Form --> */}
      <div class="form-inline">
        <div class="input-group" data-widget="sidebar-search">
          <input class="form-control form-control-sidebar" type="search" placeholder="Search" aria-label="Search"/>
          <div class="input-group-append">
            <button class="btn btn-sidebar">
              <i class="fas fa-search fa-fw"></i>
            </button>
          </div>
        </div>
      </div>

      <nav class="mt-2">
        <ul class="nav nav-pills nav-sidebar flex-column" data-widget="treeview" role="menu" data-accordion="false">
            <li class="nav-item">
            <a href="pages/calendar.html" class="nav-link">
            <i class="fas fa-list-ol"></i>
              <p>
              &nbsp;
              Category
               
              </p>
            </a>
          </li>
          <li class="nav-item">
            <a href="pages/gallery.html" class="nav-link">
            <i class="fas fa-carrot"></i>
              <p>
              &nbsp;
                Product
              </p>
            </a>
          </li>
          <li class="nav-item">
            <a href="pages/kanban.html" class="nav-link">
            <i class="fas fa-star"></i>
              <p>
              &nbsp;
               Rating
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