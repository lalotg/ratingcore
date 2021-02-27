import React, { Component } from 'react';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import data from './data/data.json'
import CarItem from './CarItem';

class Layout extends Component {
    constructor(props) {
        super(props);

        this.state = {
            cars: data
        }

    }
    render() {
        return (
            <Container>
                <Row xs={1} md={4}>
                    {  this.state.cars.map(car=>
                        <Col>
                            <CarItem 
                                car={car}
                                />
                        </Col>
                    )}
                </Row>
            </Container>
        );
    }
}

export default Layout;