import React, { Component, Fragment } from 'react';
import './style.css';

class CarItem extends Component {
    constructor(props) {
        super(props);

    }

    render() {
        return (
            <div className={(this.props.car.estimatedate!=null)?"assigned":"car"}>
                <h1>{this.props.car.make}</h1>
                <h2>{this.props.car.model}</h2>
                <figure>
                    <img src={this.props.car.image} className="figure-img img-fluid rounded" />
                    <figcaption>{this.props.car.description}</figcaption>
                </figure>
            </div>
        );
    }

};

export default CarItem;