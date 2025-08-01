function Greeting({ isLoggedIn }) {
  return <h2>{isLoggedIn ? 'Welcome back, User!' : 'Please sign up.'}</h2>;
}
export default Greeting;
