import Header from './components/Header';
import Navbar from './components/Navbar';
import CategoryForm from './Pages/Categoties/CategoryForm';
import { Router ,Switch, Route } from "react-router-dom";
import ListCategory from './Pages/Categoties/Listcategory';
import { LIST_CATEGORY,CREATE_CATEGORY, UPDATE_CATEGORY,LIST_USER, LIST_PRODUCT} from './components/router';
import history from'./Helpers/help';
import ListUser from './Pages/User/ListUser';
import ListProduct from'./Pages/Products/ListProduct';

function App() {
  return (
    
    <div className="App">
      <Navbar />
        <Header />
        <Router history={history}>
      <Switch>
        <Route path={LIST_CATEGORY}>
          <ListCategory />
        </Route>
        <Route path={CREATE_CATEGORY}>
          <CategoryForm />
        </Route>
        <Route path={UPDATE_CATEGORY}>
          <CategoryForm />
        </Route>
        <Route path={LIST_USER}>
          <ListUser />
        </Route>
        <Route path={LIST_PRODUCT}>
          <ListProduct />
        </Route>
      </Switch>
    </Router>
    </div>
  );
}

export default App;
