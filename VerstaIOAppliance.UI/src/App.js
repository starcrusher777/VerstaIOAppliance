import React, { useState } from 'react';
import OrderForm from './components/OrderForm';
import OrderList from './components/OrderList';
import OrderDetail from './components/OrderDetail';
import NavTabs from "./components/NavTabs";
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/css/bootstrap-grid.min.css'
const App = () => {
    const [view, setView] = useState('orders');
    const [selectedOrder, setSelectedOrder] = useState(null);
    const [showDetailed, setShowDetailed] = useState(false);

    const handleViewChange = (newView) => {
        setView(newView);
        if (newView === 'create') {
            setSelectedOrder(null);
        }
    };

    return (
        <>
            <div className="app-container">
                <div className="nav-tabs">
                    <NavTabs onTabChange={handleViewChange} />
                </div>
                {selectedOrder && <OrderDetail order={selectedOrder} show={showDetailed} onClose={setShowDetailed} />}

                <header className="header">
                    <h1 className="h1"></h1>
                </header>

                {view === 'create' && <OrderForm onOrderCreated={() => setView('orders')} />}
                {view === 'orders' && (
                    <OrderList onSelectOrder={setSelectedOrder} showModal={setShowDetailed} />
                )}
            </div>
        </>
    );
};

export default App;