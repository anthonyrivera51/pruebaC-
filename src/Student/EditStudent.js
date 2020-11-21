import React from 'react';
import { Container, Col, Form, Row, FormGroup, Label, Input, Button } from 'reactstrap';
import axios from 'axios'
import '../Student/Addstudent.css'
class Edit extends React.Component {
  constructor(props) {
    super(props)

    this.onChangeName = this.onChangeName.bind(this);
    this.onChangeRollNo = this.onChangeRollNo.bind(this);
    this.onChangeClass = this.onChangeClass.bind(this);
    this.onSubmit = this.onSubmit.bind(this);

    this.state = {
      codigo: '',
      name: '',
      status: ''

    }
  }

  componentDidMount() {
    axios.get('http://localhost:49220/api/region/byId?id=' + this.props.match.params.id)
      .then(response => {
        this.setState({
          codigo: response.data.data[0].codigo,
          name: response.data.data[0].name,
          status: response.data.data[0].status
        });

      })
      .catch(function (error) {
        console.log(error);
      })
  }

  onChangeName(e) {
    this.setState({
      codigo: e.target.value
    });
  }
  onChangeRollNo(e) {
    this.setState({
      name: e.target.value
    });
  }
  onChangeClass(e) {
    this.setState({
      status: e.target.value
    });
  }

  onSubmit(e) {
    e.preventDefault();
    const obj = {
      Id: this.props.match.params.id,
      codigo: this.state.codigo,
      name: this.state.name,
      status: this.state.status
    };
    axios.post('http://localhost:49220/api/region/insert/', obj)
      .then(res => console.log(res.data));
    this.props.history.push('/Studentlist')
  }
  render() {
    return (
      <Container className="App">

        <h4 className="PageHeading">Update Student Informations</h4>
        <Form className="form" onSubmit={this.onSubmit}>
          <Col>
            <FormGroup row>
              <Label for="name" sm={2}>Codigo</Label>
              <Col sm={10}>
                <Input type="text" name="Name" value={this.state.codigo} onChange={this.onChangeName}
                  placeholder="Enter Name" />
              </Col>
            </FormGroup>
            <FormGroup row>
              <Label for="Password" sm={2}>name</Label>
              <Col sm={10}>
                <Input type="text" name="RollNo" value={this.state.name} onChange={this.onChangeRollNo} placeholder="Enter RollNo" />
              </Col>
            </FormGroup>
            <FormGroup row>
              <Label for="Password" sm={2}>status</Label>
              <Col sm={10}>
                <Input type="text" name="Class" value={this.state.status} onChange={this.onChangeClass} placeholder="Enter Class" />
              </Col>
            </FormGroup>
          </Col>
          <Col>
            <FormGroup row>
              <Col sm={5}>
              </Col>
              <Col sm={1}>
                <Button type="submit" color="success">Submit</Button>{' '}
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

export default Edit;  