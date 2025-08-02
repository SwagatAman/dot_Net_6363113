import React, { useContext } from 'react';
import ThemeContext from './ThemeContext';

function EmployeeCard({ employee }) {
  const theme = useContext(ThemeContext);

  return (
    <div className={`employee-card ${theme}`}>
      <h3>{employee.name}</h3>
      <p>{employee.role}</p>
      <button className={`btn-${theme}`}>View Profile</button>
    </div>
  );
}

export default EmployeeCard;
