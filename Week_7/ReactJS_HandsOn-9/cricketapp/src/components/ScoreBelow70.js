export default function ScoreBelow70({ players }) {
  const below70 = players.filter(item => item.score < 70);
  return (
    <ul>
      {below70.map((item, index) => (
        <li key={index}>{item.name} ({item.score})</li>
      ))}
    </ul>
  );
}
