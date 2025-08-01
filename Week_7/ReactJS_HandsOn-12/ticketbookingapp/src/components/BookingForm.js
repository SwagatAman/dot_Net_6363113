import { useState } from 'react';

function BookingForm() {
  const [flightId, setFlightId] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    alert(`Ticket booked for Flight ID: ${flightId}`);
    setFlightId('');
  };

  return (
    <form onSubmit={handleSubmit}>
      <h3>Book Your Ticket</h3>
      <input
        type="text"
        placeholder="Enter Flight ID"
        value={flightId}
        onChange={(e) => setFlightId(e.target.value)}
        required
      />
      <button type="submit">Book</button>
    </form>
  );
}

export default BookingForm;
