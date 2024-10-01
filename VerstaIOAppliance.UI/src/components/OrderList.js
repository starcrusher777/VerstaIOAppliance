import React, { useState, useEffect } from 'react';
import axios from 'axios';

const OrderList = ({ onSelectOrder, showModal }) => {
    const [orders, setOrders] = useState([]);

    useEffect(() => {
        const fetchOrders = async () => {
            const response = await axios.get('http://localhost:5141/api/Orders/GetOrders/');
            const sortedOrders = response.data.sort((a, b) => new Date(b.id) - new Date(a.id));
            setOrders(sortedOrders);
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