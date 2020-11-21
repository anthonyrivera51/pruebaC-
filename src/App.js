import React from 'react';
import Addstudent from './Student/Addstudent';
import Studentlist from './Student/Studentlist';
import EditStudent from './Student/EditStudent';
import { BrowserRouter as Router, Switch, Route, Link } from 'react-router-dom';
import './App.css';
function App() {
  return (
    <Router>
      <div className="container">
        <nav className="navbar navbar-expand-lg navheader">
          <div className="collapse navbar-collapse" >
            <ul className="navbar-nav mr-auto">
              <li className="nav-item">
                <Link to={'/Addstudent'} className="nav-link">Agregar Region</Link>
              </li>
              <li className="nav-item">
                <Link to={'/Studentlist'} className="nav-link">Lista Region</Link>
              </li>
            </ul>
          </div>
        </nav> <br />
        <Switch>
          <Route exact path='/Addstudent' component={Addstudent} />
          <Route path='/edit/:id' component={EditStudent} />
          <Route path='/Studentlist' component={Studentlist} />
        </Switch>
      </div>
    </Router>
  );
}

export default App;  