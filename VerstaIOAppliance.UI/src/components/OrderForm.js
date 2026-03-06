import React, { useState } from 'react';
import api from '../api';
import { Button } from 'react-bootstrap';

const OrderForm = ({ onOrderCreated }) => {
    const [order, setOrder] = useState({
        senderCity: '',
        senderAddress: '',
        recipientCity: '',
        recipientAddress: '',
        weight: '',
        deliveryDate: '',
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setOrder({ ...order, [name]: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        const payload = {
            ...order,
            weight: String(order.weight),
            deliveryDate: order.deliveryDate,
        };
        const response = await api.post('/api/Orders/CreateOrder', payload);
        onOrderCreated(response.data);
    };

    return (
        <div className="container">
            <div className="form-box">
                <h2 className="text-color">Создать заказ</h2>
                <form className="form" onSubmit={handleSubmit}>
                    <input className="input"
                           type="text"
                           name="senderCity"
                           placeholder="Город отправителя"
                           value={order.senderCity}
                           onChange={handleChange}
                           required
                    />
                    <input className="input"
                           type="text"
                           name="senderAddress"
                           placeholder="Адрес отправителя"
                           value={order.senderAddress}
                           onChange={handleChange}
                           required
                    />
                    <input className="input"
                           type="text"
                           name="recipientCity"
                           placeholder="Город получателя"
                           value={order.recipientCity}
                           onChange={handleChange}
                           required
                    />
                    <input className="input"
                           type="text"
                           name="recipientAddress"
                           placeholder="Адрес получателя"
                           value={order.recipientAddress}
                           onChange={handleChange}
                           required
                    />
                    <input className="input"
                           type="number"
                           name="weight"
                           placeholder="Вес (кг)"
                           value={order.weight}
                           onChange={handleChange}
                           required
                    />
                    <input className="input"
                           type="date"
                           name="deliveryDate"
                           value={order.deliveryDate}
                           onChange={handleChange}
                           required
                    />
                    
                    <Button className="create-order-button" type="submit" value="Submit">Создать</Button>
                </form>
            </div>
        </div>
    );
};


export default OrderForm;