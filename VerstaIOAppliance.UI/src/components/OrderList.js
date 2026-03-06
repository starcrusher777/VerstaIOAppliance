import React, { useState, useEffect } from 'react';
import api from '../api';

const OrderList = ({ onSelectOrder, showModal }) => {
    const [orders, setOrders] = useState([]);

    useEffect(() => {
        const fetchOrders = async () => {
            const response = await api.get('/api/Orders/GetOrders');
            const data = Array.isArray(response.data) ? response.data : [];
            const sorted = [...data].sort((a, b) => (b.id || 0) - (a.id || 0));
            setOrders(sorted);
        };

        fetchOrders();
    }, []);

    return (
        <ul>
            <div className="order-list">
                <div className="order-list_header">
                    <h1 className="order-list-text-color">Список заказов</h1>
                </div>
                {
                    orders.map(order => (
                        <li className="list-style" key={order.id} onClick={() => { onSelectOrder(order); showModal(true) }}>
                        <b>{order.id}:</b> {order.senderCity} {order.senderAddress} {order.recipientCity} {order.recipientAddress} {order.createdAt}
                    </li>
                ))
            }
            </div>
        </ul>
    );
};

export default OrderList;