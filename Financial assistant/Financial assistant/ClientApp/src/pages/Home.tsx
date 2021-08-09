import * as React from 'react';
import { useEffect, useState } from 'react';

const Home = (props: {name : string}) => {

    return (
        <div>
            {props.name ? 'Hi ' + props.name : 'You are not logged in'}
        </div>
    );
};

export default Home;