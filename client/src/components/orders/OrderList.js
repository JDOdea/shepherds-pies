import { useEffect, useState } from "react";
import { deleteOrder, fetchNewestFirst, fetchOrder, fetchOrders } from "../../managers/orderManager";
import { Button, Input, Label, Modal, ModalHeader, Table } from "reactstrap";
import { OrderDetailsModal } from "./OrderDetailsModal";

export const OrderList = () => {
    const [orders, setOrders] = useState([]);
    const [filteredOrders, setfilter ] = useState([]);
    const [selectedOrder, setSelectedOrder] = useState();

    const [detailsModal, setDetailsModal] = useState(false);
    const [detailsVisible, setDetailsVisible] = useState(false);

    const detailsToggle = () => setDetailsModal(!detailsModal);

    const getAllOrders = () => {
        fetchNewestFirst().then(setOrders);
    }

    const handleDelete = (id) => {
        deleteOrder(id).then(getAllOrders);
    }

    useEffect(() => {
        getAllOrders();
    }, []);

    useEffect(() => {
        setfilter(orders);
    }, [orders]);

    const displayDateTime = (date) => {
        const displayDate = new Date(date).toUTCString().slice(0, 16);
        const displayTime = new Date(date).toLocaleTimeString().slice(0, 23);
        const dateString = `${displayDate} at ${displayTime}`;

        return dateString;
    }

    return (
        <>
            <h2>Orders</h2>
            <div className="filters">
                <Label htmlFor="sort">Sort By</Label>
                <Input
                    type="select"
                    name="sort"
                    onChange={(e) => {
                        if (e.target.value == 1) {
                            getAllOrders();
                        } else if (e.target.value == 2) {
                            fetchOrders().then(setfilter);
                        }
                    }}
                >
                    <option value="default" hidden>Select an option...</option>
                    <option value={1}>Show Newest First</option>
                    <option value={2}>Show Oldest First</option>
                </Input>
            </div>
            <Table>
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Order Taken By:</th>
                        <th>Order Type</th>
                        <th>Order Date</th>
                        <th># of Pizzas</th>
                        <th>Total Cost</th>
                        <th></th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {filteredOrders.map((o) => (
                        <tr key={`order--${o.id}`}>
                            <th scope="row">{o.id}</th>
                            <td>{o.employee.fullName}</td>
                            <td>
                                {
                                    o.driver
                                    ?
                                    "Delivery"
                                    :
                                    "Dine in"
                                }
                            </td>
                            <td>{displayDateTime(o.orderDate)}</td>
                            <td>{o.pizzas.length}</td>
                            <td>${(Math.round(o.totalCost * 100) / 100).toFixed(2)}</td>
                            <td>
                                <Button
                                    onClick={() => {
                                        fetchOrder(o.id).then(setSelectedOrder);
                                        detailsToggle();
                                    }}
                                >Details</Button>
                            </td>
                            <td>
                                <Button
                                    color="danger"
                                    onClick={() => {
                                        handleDelete(o.id);
                                    }}
                                >Cancel</Button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
            {
                detailsModal
                ?
                <Modal isOpen={detailsModal} toggle={detailsToggle}>
                    <ModalHeader toggle={detailsToggle}>Details</ModalHeader>
                    <OrderDetailsModal orderObject={selectedOrder}/>
                </Modal>
                :
                ""
            }
        </>
    )
}