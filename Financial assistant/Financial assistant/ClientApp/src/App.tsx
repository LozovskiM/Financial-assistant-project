import * as React from 'react';
import { useEffect, useState } from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import './App.css';
import Nav from './components/Nav';
import Home from './pages/Home';
import Login from './pages/Login';
import Register from './pages/Register';


function App() {

    const [name, setName] = useState('');

    useEffect(() => {
        (
            async () => {
                const response = await fetch('https://localhost:44385/api/user', {
                    headers: { 'Content-Type': 'application/json' },
                    credentials: 'include'
                });
                const content = await response.json();

                setName(content.name);
            }
        )();
    });

    return (
        <div className="App">
            <BrowserRouter>
                <Nav name={name} setName={setName}/>

                <main className="form-signin">
                    <Switch>
                        <Route path="/" exact component={() => <Home name={name}/>} />
                        <Route path="/login" component={() => <Login setName={setName} />}/>
                        <Route path="/register" component={Register} />
                    </Switch>
                </main>
            </BrowserRouter>
        </div>
     );
}


export default App;