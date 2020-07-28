import React from 'react';
import logo from './logo.svg';
import './App.css';
import Square from './Component/Square';
import Hello from './Component/Hello';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          TEST <code>src/App.js</code> and save to reload.
        </p>
        <Square value={7} />
        <h1>Name:</h1>
        <Hello name='john' />
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

export default App;
