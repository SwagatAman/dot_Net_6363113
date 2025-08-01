import React from "react";
import ListOfPlayers, { players } from "./components/ListOfPlayers";
import ScoreBelow70 from "./components/ScoreBelow70";
import OddPlayers from "./components/OddPlayers";
import EvenPlayers from "./components/EvenPlayers";
import ListIndianPlayers from "./components/IndianPlayers";

function App() {
  const flag = true; // Change to false to toggle

  return (
    <div>
      {flag ? (
        <div>
          <h1>List of Players:</h1>
          <ListOfPlayers players={players} />
          <h1>List of Players having Scores Less than 70</h1>
          <ScoreBelow70 players={players} />
        </div>
      ) : (
        <div>
          <h1>Indian Team</h1>
          <h1>Odd Players</h1>
          <OddPlayers {...[players]} />

          <h1>Even Players</h1>
          <EvenPlayers {...[players]} />

          <h1>List of Indian Players Merged:</h1>
          <ListIndianPlayers />
        </div>
      )}
    </div>
  );
}

export default App;
