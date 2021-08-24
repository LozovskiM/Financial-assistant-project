import * as React from 'react';
import { Link, Redirect } from 'react-router-dom';
import { SyntheticEvent, useState } from 'react';
import Marquee from "react-fast-marquee";

const Currencies = () => {

    return (
        <div id="news-bar">
            <Marquee direction="right" pauseOnHover={true} gradient={false} speed={40}>
                <a href="#">الخبر الاول</a><a> -*- </a>
                <a href="#">الخبر الثاني</a><a> -*- </a>
                <a href="#">الخبر الثالث</a><a> -*- </a>
                <a href="#">الخبر الرابع</a><a> -*- </a>
                <a href="#">الخبر الخامس</a><a> -*- </a>
            </Marquee>
        </div>
    );
};

export default Currencies;