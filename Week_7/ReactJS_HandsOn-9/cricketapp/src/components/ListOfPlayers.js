const players = [
  { name: "Swagat", score: 80 },
  { name: "Vidit", score: 65 },
  { name: "Aftaf", score: 90 },
  { name: "Adarsh", score: 30 },
  { name: "Nikhil", score: 75 },
  { name: "Purbasha", score: 45 },
  { name: "Ayush", score: 55 },
  { name: "Shekriwal", score: 95 },
  { name: "Swayam", score: 85 },
  { name: "Robert", score: 60 },
  { name: "Ashutosh", score: 35 },
];

export default function ListOfPlayers({ players }) {
  return (
    <ul>
      {players.map((item, index) => (
        <li key={index}>{item.name} ({item.score})</li>
      ))}
    </ul>
  );
}

export { players };
