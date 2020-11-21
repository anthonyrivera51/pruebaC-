import React from 'react';
import axios from 'axios';
import '../Student/Addstudent.css'
import { Container, Col, Form, Row, FormGroup, Label, Input, Button } from 'reactstrap';
class Addstudent extends React.Component {
  constructor(props) {
    super(props)
    this.state = {
      Name: '',
      RollNo: '',
      Class: '',
      Address: ''
    }
  }
  Addstudent = () => {
    axios.post('http://localhost:49220/api/region/insert/', {
      codigo: this.state.codigo, name: this.state.name,
      status: this.state.status, Address: this.state.Address
    })
      .then(json => {
        if (json.data.Status === 'Success') {
          console.log(json.data.Status);
          alert("Data Save Successfully");
          this.props.history.push('/Studentlist')
        }
        else {
          alert('Data not Saved');
          debugger;
          this.props.history.push('/Studentlist')
        }
      })
  }

  handleChange = (e) => {
    this.setState({ [e.target.name]: e.target.value });
  }

  render() {
    return (
      <Container className="App">
        <h4 className="PageHeading">Enter Student Informations</h4>
        <Form className="form">
          <Col>
            <FormGroup row>
              <Label for="name" sm={2}>Codigo</Label>
              <Col sm={10}>
                <Input type="text" name="Name" onChange={this.handleChange} value={this.state.codigo} placeholder="Enter Codigo" />
              </Col>
            </FormGroup>
            <FormGroup row>
              <Label for="address" sm={2}>Nombre</Label>
              <Col sm={10}>
                <Input type="text" name="RollNo" onChange={this.handleChange} value={this.state.name} placeholder="Enter Nombre" />
              </Col>
            </FormGroup>
            <FormGroup row>
              <Label for="Password" sm={2}>Status</Label>
              <Col sm={10}>
                <Input type="text" name="Class" onChange={this.handleChange} value={this.state.status} placeholder="Enter 1 or 0" />
              </Col>
            </FormGroup>
          </Col>
          <Col>
            <FormGroup row>
              <Col sm={5}>
              </Col>
              <Col sm={1}>
                <button type="button" onClick={this.Addstudent} className="btn btn-success">Submit</button>
              </Col>
              <Col sm={1}>
                <Button color="danger">Cancel</Button>{' '}
              </Col>
              <Col sm={5}>
              </Col>
            </FormGroup>
          </Col>
        </Form>
      </Container>
    );
  }

}

export default Addstudent; 