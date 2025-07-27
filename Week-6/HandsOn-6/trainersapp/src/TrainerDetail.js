import { useParams } from 'react-router-dom';
import trainerMock from './trainersMock';

const TrainerDetail = () => {
  const { id } = useParams();
  const trainer = trainerMock.find((t) => t.id === id);

  return (
    <div>
      <h3>Trainer Details</h3>
      <p><strong>{trainer.name}</strong> ({trainer.technology})</p>
      <p>{trainer.email}</p>
      <p>{trainer.phone}</p>
      <ul>
        {trainer.skills.map((skill, index) => (
          <li key={index}>{skill}</li>
        ))}
      </ul>
    </div>
  );
};

export default TrainerDetail;
