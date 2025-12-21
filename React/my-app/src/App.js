import logo from './logo.svg';
import './App.css';

function App() {
  function handleClick(){
    alert("Button clicked!");
  }

  (x)=>{
    alert("Hello!"+x);
  }
  const colours=["red","green","blue"];
  const [red,green,blue]=colours;
  console.log(red);

  const add=(a,b)=>a+b;
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
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
