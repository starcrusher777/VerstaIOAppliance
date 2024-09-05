import React from 'react';
import Modal from 'react-bootstrap/Modal';
import Button from 'react-bootstrap/Button';


const OrderDetail = ({order, show, onClose}) => {
    if (!order) return <div className="order-details">Выберите заказ для просмотра.</div>;

    return (
        <Modal
            show={show}
            onHide={onClose}
            backdrop="static"
            keyboard={false}
        >
            <Modal.Header closeButton>
                <Modal.Title className="text-color">Детали заказа</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <p>Номер заказа: <b>{order.id}</b></p>
                <p>Город отправителя: <b>{order.senderCity}</b></p>
                <p>Адрес отправителя: <b>{order.senderAddress}</b></p>
                <p>Город получателя: <b>{order.recipientCity}</b></p>
                <p>Адрес получателя: <b>{order.recipientAddress}</b></p>
                <p>Вес груза: <b>{order.weight} кг.</b></p>
                <p>Дата забора: <b>{order.deliveryDate.slice(0, 10)}</b></p>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={() => onClose(false)}>
                    Закрыть
                </Button>
            </Modal.Footer>
        </Modal>
    );
};

export default OrderDetail;

