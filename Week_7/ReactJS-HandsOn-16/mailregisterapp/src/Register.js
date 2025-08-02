import React, { Component } from 'react';

class Register extends Component {
  constructor() {
    super();
    this.state = {
      fullName: '',
      email: '',
      password: '',
      errors: {
        fullName: '',
        email: '',
        password: ''
      }
    };
  }

  handleChange = (event) => {
    const { name, value } = event.target;
    let errors = this.state.errors;

    switch (name) {
      case 'fullName':
        errors.fullName = value.length < 5 ? 'Full Name must be at least 5 characters long!' : '';
        break;
      case 'email':
        const validEmailRegex = RegExp(/^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@(([^<>()[\]\\.,;:\s@"]+\.)+[^<>()[\]\\.,;:\s@"]{2,})$/i);
        errors.email = validEmailRegex.test(value) ? '' : 'Email is not valid!';
        break;
      case 'password':
        errors.password = value.length < 8 ? 'Password must be at least 8 characters long!' : '';
        break;
      default:
        break;
    }

    this.setState({ errors, [name]: value });
  }

  validateForm = (errors) => {
    return Object.values(errors).every(error => error === '');
  }

  handleSubmit = (event) => {
    event.preventDefault();
    if (this.validateForm(this.state.errors)) {
      alert(`${this.state.fullName} ${this.state.email} Registered Successfully`);
    } else {
      alert('Invalid Form');
    }
  }

  render() {
    const { errors } = this.state;

    return (
      <div style={{ textAlign: 'center', marginTop: '50px' }}>
        <h2 style={{ color: 'red' }}>Register Here!!!</h2>
        <form onSubmit={this.handleSubmit}>
          <div>
            <label>Name: </label>
            <input
              type="text"
              name="fullName"
              onChange={this.handleChange}
              required
            />
            <div style={{ color: 'red' }}>{errors.fullName}</div>
          </div>
          <br />
          <div>
            <label>Email: </label>
            <input
              type="text"
              name="email"
              onChange={this.handleChange}
              required
            />
            <div style={{ color: 'red' }}>{errors.email}</div>
          </div>
          <br />
          <div>
            <label>Password: </label>
            <input
              type="password"
              name="password"
              onChange={this.handleChange}
              required
            />
            <div style={{ color: 'red' }}>{errors.password}</div>
          </div>
          <br />
          <button type="submit">Submit</button>
        </form>
      </div>
    );
  }
}

export default Register;
