import React, { useState } from 'react';
import BookDetails from './components/BookDetails';
import BlogDetails from './components/BlogDetails';
import CourseDetails from './components/CourseDetails';

function App() {
  const [showBlog, setShowBlog] = useState(false);

  return (
    <div>
      <div className="section">
        <h1>📚 Book Details</h1>
        <BookDetails />
      </div>

      <div className="section">
        <h1>📰 Blog Details</h1>
        <button onClick={() => setShowBlog(prev => !prev)}>
          {showBlog ? 'Hide Blogs' : 'Show Blogs'}
        </button>
        {showBlog && <BlogDetails />}
      </div>

      <div className="section">
        <h1>📘 Course Details</h1>
        <CourseDetails />
      </div>
    </div>
  );
}

export default App;
