import Header from './components/Header';
import Navbar from './components/Navbar';
import CategoryForm from './Pages/Categoties/CategoryForm';
import { BrowserRouter ,Switch, Route } from "react-router-dom";
import ListCategory from './Pages/Categoties/Listcategory';
import { LIST_CATEGORY,CREATE_CATEGORY } from './components/router';

function App() {
  return (
    <div className="App">
      <Navbar />
        <Header />
      <BrowserRouter>
      <Switch>
        <Route path={LIST_CATEGORY}>
          <ListCategory />
        </Route>
        <Route path={CREATE_CATEGORY}>
          <CategoryForm />
        </Route>
      </Switch>
    </BrowserRouter>
     
        


    </div>
  );
}

export default App;
