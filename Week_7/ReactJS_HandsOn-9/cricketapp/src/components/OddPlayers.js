export default function OddPlayers([first, , third, , fifth]) {
  return (
    <ul>
      <li>First: {first.name}</li>
      <li>Third: {third.name}</li>
      <li>Fifth: {fifth.name}</li>
    </ul>
  );
}
