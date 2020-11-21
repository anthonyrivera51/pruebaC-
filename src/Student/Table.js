import React, { Component } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
class Table extends Component {
  constructor(props) {
    super(props);
  }

  DeleteStudent = () => {
    axios.delete('http://localhost:49220/api/region/Delete?id=' + this.props.obj.Id)
      .then(json => {
        if (json.data.Status === 'Delete') {
          alert('Record deleted successfully!!');
        }
      })
  }
  render() {
    return (
      <tr>
        <td>
          {this.props.obj.codigo}
        </td>
        <td>
          {this.props.obj.name}
        </td>
        <td>
          {this.props.obj.status}
        </td>
        <td>
          <Link to={"/edit/" + this.props.obj.id} className="btn btn-success">Edit</Link>
        </td>
        <td>
          <button type="button" onClick={this.DeleteStudent} className="btn btn-danger">Delete</button>
        </td>
      </tr>
    );
  }
}

export default Table;  