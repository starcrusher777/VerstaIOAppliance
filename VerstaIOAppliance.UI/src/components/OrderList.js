import React, { useState, useEffect } from 'react';
import axios from 'axios';

const OrderList = ({ onSelectOrder, showModal }) => {
    const [orders, setOrders] = useState([]);

    useEffect(() => {
        const fetchOrders = async () => {
            const response = await axios.get('http://localhost:5141/api/Orders/GetOrders/');
            setOrders(response.data);
        };

        fetchOrders();
    }, []);

    return (
        <ul>
            <div className="order-list">
                <h1 className="text-color">Список заказов</h1>
            { 
                orders.map(order => (
                    <li className="list-style" key={order.id} onClick={() => { onSelectOrder(order); showModal(true) }}>
                        <b>{order.id}</b> - {order.senderCity} - {order.recipientCity}
                    </li>
                ))
            }
            </div>
        </ul>
    );
};

export default OrderList;