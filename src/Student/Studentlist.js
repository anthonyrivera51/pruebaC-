import React, { Component } from 'react';
import axios from 'axios';
import Table from './Table';

export default class Studentlist extends Component {

  constructor(props) {
    super(props);
    this.state = { business: [] };
  }
  componentDidMount() {
    axios.get('http://localhost:49220/api/region/list')
      .then(response => {
        console.log(">>>> data: ", response.data.data)
        this.setState({ business: response.data.data });

      })
      .catch(function (error) {
        console.log(error);
      })
  }

  tabRow() {
    return this.state.business.map(function (object, i) {
      return <Table obj={object} key={i} />;
    });
  }

  render() {
    return (
      <div>
        <h4 align="center">Region</h4>
        <table className="table table-striped" style={{ marginTop: 10 }}>
          <thead>
            <tr>
              <th>Codigo</th>
              <th>Nombre</th>
              <th>Estado</th>
              <th colSpan="5">Action</th>
            </tr>
          </thead>
          <tbody>
            {this.tabRow()}
          </tbody>
        </table>
      </div>
    );
  }
}  