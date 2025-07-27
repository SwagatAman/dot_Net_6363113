import React from "react";

class CountPeople extends React.Component {
  constructor() {
    super();
    this.state = {
      entrycount: 0,
      exitcount: 0
    };
  }

  updateEntry() {
    this.setState((prevState) => ({
      entrycount: prevState.entrycount + 1
    }));
  }

  updateExit() {
    this.setState((prevState) => ({
      exitcount: prevState.exitcount + 1
    }));
  }

  render() {
    return (
      <div style={{ textAlign: "center", marginTop: "50px" }}>
        <button onClick={() => this.updateEntry()} style={{ marginRight: "20px", backgroundColor: "lightgreen", padding: "10px" }}>
          Login
        </button>
        <button onClick={() => this.updateExit()} style={{ backgroundColor: "#f08080", padding: "10px" }}>
          Exit
        </button>

        <div style={{ marginTop: "20px", fontSize: "18px" }}>
          <p style={{ color: "green" }}>🟢 {this.state.entrycount} People Entered!!!</p>
          <p style={{ color: "red" }}>🔴 {this.state.exitcount} People Left!!!</p>
        </div>
      </div>
    );
  }
}

export default CountPeople;
