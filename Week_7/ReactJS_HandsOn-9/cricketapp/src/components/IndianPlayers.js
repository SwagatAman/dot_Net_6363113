const T20Players = ["Second Player", "Third Player"];
const RanjiTrophyPlayers = ["Fourth Player", "Fifth Player", "Sixth Player"];

const IndianPlayers = [...T20Players, ...RanjiTrophyPlayers];

export default function ListIndianPlayers() {
  return (
    <ul>
      {IndianPlayers.map((player, index) => (
        <li key={index}>{player}</li>
      ))}
    </ul>
  );
}

export { IndianPlayers };
