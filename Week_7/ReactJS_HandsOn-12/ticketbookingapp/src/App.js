import React, { useState } from 'react';
import Greeting from './components/Greeting';
import LoginButton from './components/LoginButton';
import LogoutButton from './components/LogoutButton';
import FlightList from './components/FlightList';
import BookingForm from './components/BookingForm';

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const handleLogin = () => setIsLoggedIn(true);
  const handleLogout = () => setIsLoggedIn(false);

  return (
    <div>
      <Greeting isLoggedIn={isLoggedIn} />
      {isLoggedIn ? (
        <>
          <LogoutButton onClick={handleLogout} />
          <FlightList />
          <BookingForm />
        </>
      ) : (
        <>
          <LoginButton onClick={handleLogin} />
          <FlightList />
        </>
      )}
    </div>
  );
}

export default App;
