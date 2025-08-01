import React from 'react';

function CourseDetails() {
  const courses = [
    { name: 'Angular', date: '6/1/2021' },
    { name: 'React', date: '6/2/2021' }
  ];

  return (
    <ul>
      {courses.map((course, index) => (
        <li key={index}>
          <strong>{course.name}</strong> - {course.date}
        </li>
      ))}
    </ul>
  );
}

export default CourseDetails;
