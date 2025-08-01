import React from 'react';

export const books = [
  { id: 101, name: "Master React", price: 570 },
  { id: 102, name: "Deep Dive into Angular 11", price: 800 },
  { id: 103, name: "Mongo Essentials", price: 450 }
];

function BookDetails() {
  return (
    <ul>
      {books.map((book) => (
        <li key={book.id}>
          <h3>{book.name}</h3>
          <h4>₹{book.price}</h4>
        </li>
      ))}
    </ul>
  );
}

export default BookDetails;
