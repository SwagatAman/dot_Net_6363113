import React from "react";

export default function ClickEvent() {
  const handleClick = (e) => {
    alert("Button was clicked");
  };

  return (
    <div>
      <button onClick={handleClick}>Click Me</button>
    </div>
  );
}
