import React from "react";
import Counter from "./components/Counter";
import Welcome from "./components/Welcome";
import ClickEvent from "./components/ClickEvent";
import CurrencyConverter from "./components/CurrencyConverter";

function App() {
  return (
    <div>
      <Counter />
      <Welcome />
      <ClickEvent />
      <CurrencyConverter />
    </div>
  );
}

export default App;
