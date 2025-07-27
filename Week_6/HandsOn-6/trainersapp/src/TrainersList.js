import { Link } from 'react-router-dom';
import trainerMock from './trainersMock';

const TrainersList = () => {
  return (
    <div>
      <h3>Trainers List</h3>
      <ul>
        {trainerMock.map((trainer) => (
          <li key={trainer.id}>
            <Link to={`/trainer/${trainer.id}`}>{trainer.name}</Link>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default TrainersList;
