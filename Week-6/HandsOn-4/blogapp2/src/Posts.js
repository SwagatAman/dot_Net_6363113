
import React from 'react';

class Posts extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            posts: []
        };
    }

    loadPosts = () => {
        fetch('https://jsonplaceholder.typicode.com/posts')
            .then(response => response.json())
            .then(data => this.setState({ posts: data.slice(0, 10) })) // Limiting to 10 posts
            .catch(error => {
                console.error('Error fetching posts:', error);
                throw error; // Will be caught in componentDidCatch
            });
    }

    componentDidMount() {
        this.loadPosts();
    }

    componentDidCatch(error, info) {
        alert("An error occurred: " + error.message);
        console.error("Error info:", info);
    }

    render() {
        return (
            <div style={{ padding: "20px" }}>
                <h2>Latest Posts</h2>
                {this.state.posts.map(post => (
                    <div key={post.id} style={{ marginBottom: "20px" }}>
                        <h3>{post.title}</h3>
                        <p>{post.body}</p>
                        <hr />
                    </div>
                ))}
            </div>
        );
    }
}

export default Posts;
