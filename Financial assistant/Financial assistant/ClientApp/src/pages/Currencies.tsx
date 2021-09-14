import * as React from 'react';
import { SyntheticEvent, useEffect, useState } from 'react';
import { Redirect } from 'react-router-dom';

const Currencies = () => {


    return (
        <div className="content">
            <div className="container">
                <div className="table-responsive">
                    <table className="table table-striped custom-table">
                        <thead>
                            <tr>
                                <th scope="col">Currency</th>
                                <th scope="col">Code</th>
                                <th scope="col">Convertation currency</th>
                                <th scope="col">Exchange rate</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    1392
                                </td>
                                <td><a href="#">James Yates</a></td>
                                <td>
                                    Web Designer
                                    <small className="d-block">Far far away, behind the word mountains</small>
                                </td>
                                <td>+63 983 0962 971</td>
                                <td>NY University</td>
                                <td><a href="#" className="more">Details</a></td>

                            </tr>

                            <tr>

                                <td>4616</td>
                                <td><a href="#">Matthew Wasil</a></td>
                                <td>
                                    Graphic Designer
                                    <small className="d-block">Far far away, behind the word mountains</small>
                                </td>
                                <td>+02 020 3994 929</td>
                                <td>London College</td>
                                <td><a href="#" className="more">Details</a></td>
                            </tr>
                            <tr>

                                <td>9841</td>
                                <td><a href="#">Sampson Murphy</a></td>
                                <td>
                                    Mobile Dev
                                    <small className="d-block">Far far away, behind the word mountains</small>
                                </td>
                                <td>+01 352 1125 0192</td>
                                <td>Senior High</td>
                                <td><a href="#" className="more">Details</a></td>
                            </tr>
                            <tr>

                                <td>9548</td>
                                <td><a href="#">Gaspar Semenov</a></td>
                                <td>
                                    Illustrator
                                    <small className="d-block">Far far away, behind the word mountains</small>
                                </td>
                                <td>+92 020 3994 929</td>
                                <td>College</td>
                                <td><a href="#" className="more">Details</a></td>
                            </tr>

                            <tr>

                                <td>4616</td>
                                <td><a href="#">Matthew Wasil</a></td>
                                <td>
                                    Graphic Designer
                                    <small className="d-block">Far far away, behind the word mountains</small>
                                </td>
                                <td>+02 020 3994 929</td>
                                <td>London College</td>
                                <td><a href="#" className="more">Details</a></td>
                            </tr>
                            <tr>

                                <td>9841</td>
                                <td><a href="#">Sampson Murphy</a></td>
                                <td>
                                    Mobile Dev
                                    <small className="d-block">Far far away, behind the word mountains</small>
                                </td>
                                <td>+01 352 1125 0192</td>
                                <td>Senior High</td>
                                <td><a href="#" className="more">Details</a></td>
                            </tr>
                            <tr>

                                <td>9548</td>
                                <td><a href="#">Gaspar Semenov</a></td>
                                <td>
                                    Illustrator
                                    <small className="d-block">Far far away, behind the word mountains</small>
                                </td>
                                <td>+92 020 3994 929</td>
                                <td>College</td>
                                <td><a href="#" className="more">Details</a></td>
                            </tr>

                        </tbody>
                    </table>
                </div>


            </div>

        </div>
    );
};

export default Currencies;