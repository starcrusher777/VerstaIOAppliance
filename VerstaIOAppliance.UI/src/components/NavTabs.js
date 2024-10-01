import Nav from "react-bootstrap/Nav"
import 'bootstrap/dist/css/bootstrap-grid.min.css'
import React from "react";
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Button from 'react-bootstrap/Button';


function NavTabs({onTabChange}) {
    return (
        <Nav variant="tabs" defaultActiveKey="orders">
            <Nav.Item>
                <Nav.Link eventKey="orders" onClick={() => onTabChange('orders')}>
                    Список заказов
                </Nav.Link>
            </Nav.Item>
            <Nav.Item>
                <Nav.Link eventKey="create" onClick={() => onTabChange('create')}>
                    Создать заказ
                </Nav.Link>
            </Nav.Item>
            <Form className="search" inline>
                <Row>
                    <Col xs="auto">
                        <Form.Control
                            type="text"
                            placeholder="Search"
                            className="search-box"
                        />
                    </Col>
                    <Col xs="auto">
                        <Button className="search-button" type="submit">Submit</Button>
                    </Col>
                </Row>
            </Form>
        </Nav>
    );
}
export default NavTabs;