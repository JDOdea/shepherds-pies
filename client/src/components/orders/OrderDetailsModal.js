import React, { useEffect, useState } from "react";
import { Label, ModalBody } from "reactstrap"
import { fetchSize } from "../../managers/sizeManager";

export const OrderDetailsModal = ({ orderObject }) => {
    const [order, setOrder] = useState({});
    const [size, setSize] = useState(null);
    const [cheese, setCheese] = useState(null);
    const [sauce, setSauce] = useState(null);


    useEffect(() => {
        setOrder(orderObject);
    }, [orderObject]);

    if (!order) {
        return null;
    }

    return (
        <ModalBody>
            <div>
                <Label>
                    <ul>
                        <u>
                            <b>
                                Ordered on {new Date(orderObject?.orderDate).toUTCString().slice(0, 16)} at {new Date(orderObject?.orderDate).toLocaleTimeString().slice(0, 23)} for {
                                    orderObject?.tableNumber
                                    ?
                                    `Table ${orderObject?.tableNumber}`
                                    :
                                    "delivery"
                                }
                            </b>
                        </u>
                    </ul>
                </Label>
                {
                    order.pizzas
                    ?
                    order.pizzas.map((op) => (
                        <React.Fragment key={`orderPizza--${op.id}`}>
                            <div>
                                <b><u>Pizza #{op.id}</u></b><br />
                                <b>Cheese:</b> {op.cheese.type}<br />
                                <b>Sauce:</b> {op.sauce.type}<br />
                                <b>Toppings: </b>
                                <ul>
                                    {
                                        op.pizzaToppings.map((pt) => (
                                            <li key={`orderPizzaTopping--${pt.id}`}>
                                                <div>{pt.topping.name}</div>
                                            </li>
                                        ))
                                    }
                                </ul>
                                <u><b>Cost:</b> ${(Math.round(op.cost * 100) / 100).toFixed(2)}</u>
                            </div><br />
                        </React.Fragment>
                    ))
                    :
                    ""
                }
                <br />
            </div>
            <div className="orderEmployeeNames">
                <b>Taken By:</b> {order?.employee?.fullName} 
                {
                    order.driverId
                    ?
                    <React.Fragment>
                        <b> Driven By:</b> {order?.driver?.fullName}
                    </React.Fragment>
                    :
                    ""
                }

            </div>
            <div className="orderTotalCost">
                <b><u>TOTAL COST:<br />${(Math.round(order.totalCost * 100) / 100).toFixed(2)}</u></b>
            </div>
        </ModalBody>
    )
}