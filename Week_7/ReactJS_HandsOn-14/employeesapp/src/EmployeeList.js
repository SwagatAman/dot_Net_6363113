import React from 'react';
import EmployeeCard from './EmployeeCard';

const employeeData = [
  { id: 1, name: 'Alice Johnson', role: 'Developer' },
  { id: 2, name: 'Bob Smith', role: 'Designer' },
  { id: 3, name: 'Charlie Brown', role: 'Manager' },
];

function EmployeeList() {
  return (
    <div className="employee-list">
      {employeeData.map(emp => (
        <EmployeeCard key={emp.id} employee={emp} />
      ))}
    </div>
  );
}

export default EmployeeList;
