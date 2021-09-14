import * as React from 'react';
import { Link } from 'react-router-dom';

const Nav = (props: { name: string, setName: (name: string) => void }) => {

    const logout = async () => {
        await fetch('https://localhost:44385/api/auth/logout', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            credentials: 'include'
        });

        props.setName('');
    }
    let menu;

    if (props.name === undefined) {
        menu = (
            <ul className="headerul">
                <li className="headerli">
                        <Link to="/login" className="linkfonts" style={{ textDecoration: 'none' }}>Login</Link>
                </li>
                <li className="headerli">
                        <Link to="/register" className="linkfonts" style={{ textDecoration: 'none' }}>Register</Link>
                </li>
            </ul>
        )
    }else {
        menu = (
            <ul className="headerul">
                <li className="headerli">
                    <Link to="/account" className="linkfonts" style={{ textDecoration: 'none' }}>My account</Link>
                </li>
                <li className="headerli">
                    <Link to="/backaccounts" className="linkfonts" style={{ textDecoration: 'none' }}>Bank accounts</Link>
                </li>
                <li className="headerli">
                    <Link to="/currencies" className="linkfonts" style={{ textDecoration: 'none' }}>Currencies</Link>
                </li>
                <li className="headerli">
                    <Link to="/login" className="linkfonts" style={{ textDecoration: 'none' }} onClick={logout}>Logout</Link>
                </li>
            </ul>
            )
    }


    return (
            <div className="headerdiv">
                    {menu}
            </div>
    );
};

export default Nav;