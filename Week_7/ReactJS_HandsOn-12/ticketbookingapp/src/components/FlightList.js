const flights = [
  { id: 1, from: 'Delhi', to: 'Mumbai', price: 3500 },
  { id: 2, from: 'Chennai', to: 'Bangalore', price: 2000 },
];

function FlightList() {
  return (
    <div>
      <h3>Available Flights</h3>
      <ul>
        {flights.map(flight => (
          <li key={flight.id}>
            {flight.from} → {flight.to} @ ₹{flight.price}
          </li>
        ))}
      </ul>
    </div>
  );
}
export default FlightList;
