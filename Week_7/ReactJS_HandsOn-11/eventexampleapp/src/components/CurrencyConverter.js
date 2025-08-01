import React, { useState } from "react";

export default function CurrencyConverter() {
  const [amount, setAmount] = useState("");
  const [converted, setConverted] = useState(null);

  const handleSubmit = (e) => {
    e.preventDefault(); // Prevents form reload
    const euro = (parseFloat(amount) / 90).toFixed(2);
    setConverted(euro);
  };

  return (
    <div>
      <h2 style={{ color: "green" }}>Currency Convertor!!!</h2>
      <form onSubmit={handleSubmit}>
        <label>Amount:</label>
        <input
          type="text"
          value={amount}
          onChange={(e) => setAmount(e.target.value)}
        />
        <br />
        <label>Currency:</label>
        <input type="text" value="INR to Euro" readOnly />
        <br />
        <button type="submit">Convert</button>
      </form>
      {converted && (
        <h4>
          Converted Amount: <strong>€ {converted}</strong>
        </h4>
      )}
    </div>
  );
}
