import React from "react";

export default function Welcome() {
  const sayMessage = (msg) => {
    alert(`Say ${msg}`);
  };

  return (
    <div>
      <button onClick={() => sayMessage("Welcome")}>Say Welcome</button>
    </div>
  );
}
