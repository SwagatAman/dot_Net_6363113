import React from 'react';
import CohortDetails from './components/CohortDetails';

function App() {
  const cohorts = [
    {
      name: 'INTADMDF10 - .NET FSD',
      startDate: '22-Feb-2022',
      status: 'Completed',
      coach: 'Ashna',
      trainer: 'Jijo Jose'
    },
    {
      name: 'ADM21FJ014 - Java FSD',
      startDate: '10-Sep-2021',
      status: 'Ongoing',
      coach: 'Elisa Smith',
      trainer: 'Ayaan'
    },
    {
      name: 'CDFJ8F1025 - Java FSD',
      startDate: '24-Oct-2021',
      status: 'Completed',
      coach: 'Ananya',
      trainer: 'John Doe'
    }
  ];

  return (
    <div style={{ padding: '20px' }}>
      <h2>Cohorts Details</h2>
      {cohorts.map((cohort, index) => (
        <CohortDetails key={index} cohort={cohort} />
      ))}
    </div>
  );
}

export default App;
