import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom"
import { fetchOrder, putOrder } from "../../managers/orderManager";
import { Alert, Button, Card, CardBody, CardText, CardTitle, FormGroup, Input, InputGroup, InputGroupText, Label, Modal, ModalHeader } from "reactstrap";
import { fetchAllUsers } from "../../managers/userManager";
import { EditOrderPizzaModal } from "./EditOrderPizzaModal";


export const EditOrder = () => {
    const { id } = useParams();

    const [order, setOrder] = useState(null);
    const [orderPizzas, setOrderPizzas] = useState([]);
    const [employees, setEmployees] = useState([]);
    const [dineIn, setDineIn] = useState(false);
    const [tableNumber, setTableNumber] = useState(null);
    const [hasDriver, setHasDriver] = useState(false);
    const [driverId, setDriverId] = useState(null);
    const [tip, setTip] = useState(0.00);

    const [selectedPizza, setSelectedPizza] = useState({});
    const [detailsModal, setDetailsModal] = useState(false);
    const [visible, setVisible] = useState(false);
    const onDismiss = () => setVisible(false);

    const detailsToggle = () => setDetailsModal(!detailsModal);


    const [orderBuilder, setOrderBuilder] = useState(
        {
            employeeId: 0,
            tableNumber: null,
            driverId: null,
            tipped: null
        }
    );
    const [orderBuilderCurrentPizza, setOrderBuilderCurrentPizza] = useState(
        {
            sizeId: 0,
            cheeseId: 0,
            sauceId: 0,
            toppingIds: []
        }
    );

    const navigate = useNavigate();



    const handleOrderEdit = () => {
        const copy = structuredClone(orderBuilder)
        copy.employeeId = order.employeeId;
        copy.tableNumber = order.tableNumber;
        copy.driverId = order.driverId;
        copy.tipped = order.tipped

        setOrderBuilder(copy);

        const pizzaCopy = structuredClone(orderBuilderCurrentPizza);
    }

    const handleOrderUpdate = () => {

        if (!tableNumber && !driverId) {
            setVisible(true);
            return;
        }

        const updatedOrder = {
            id: order.id,
            employeeId: orderBuilder.employeeId,
            tableNumber: tableNumber,
            driverId: driverId,
            tipped: tip,
            orderDate: order.orderDate,
            pizzas: orderPizzas
        }

        putOrder(updatedOrder.id, updatedOrder)
            .then(() => {
                navigate("/orders");
            })
    }

    useEffect(() => {
        fetchOrder(id).then(setOrder);

        fetchAllUsers().then((res) => {
            const filteredEmployees = res.filter(e => {
                return e.firstName !== "Admina";
            })
            setEmployees(filteredEmployees);
        })

    }, []);

    useEffect(() => {
        if (order) {
            handleOrderEdit();
            setOrderPizzas(order.pizzas);
            if (order.tableNumber) {
                setDineIn(true);
                setTableNumber(order.tableNumber);
            } else {
                setHasDriver(true);
                setDriverId(order.driverId);
            }
            if (order.tipped) {
                setTip(order.tipped);
            }
        }
    }, [order]);

    useEffect(() => {
        if (selectedPizza) {
            const copy = structuredClone(orderPizzas);
            const newPizza = selectedPizza;
            const oldPizzaIndex = orderPizzas.indexOf(orderPizzas.find((op) => {
                return op.id === selectedPizza.id;
            }));
            copy[oldPizzaIndex] = newPizza;
            setOrderPizzas(copy);
        }
    }, [selectedPizza]);

    if (!order || !orderPizzas) return;

    return (
        <div className="container">
            <h4><u>Edit Order</u></h4>
            <div className="alert-float">
                <Alert color="info" isOpen={visible} toggle={onDismiss}>
                    Please fill all form inputs
                </Alert>
            </div>
            <div className="editOrder">
                <div className="editOrderPizzas">
                    {orderPizzas.map(op => (
                            <Card 
                            key={`op--${orderPizzas.indexOf(op) + 1}`}
                            style={{
                                width: '18rem'
                            }}>
                                <CardBody>
                                    <CardTitle>
                                        <b><u>#{orderPizzas.indexOf(op) + 1}. {op.size.name} Pizza</u></b><br />
                                    </CardTitle>
                                    <CardText tag={`div`}>
                                        <b>Cheese:</b> {op.cheese.type}<br />
                                        <b>Sauce:</b> {op.sauce.type}<br />
                                        <b>Toppings: </b>
                                        <ul>
                                            {op.pizzaToppings.map((pt) => (
                                                <li key={`op${orderPizzas.indexOf(op) + 1}--${orderPizzas[orderPizzas.indexOf(op)].pizzaToppings.indexOf(pt) + 1}`}>
                                                    <div>{pt.topping.name} {`(${pt.quantity})`}</div>
                                                </li>
                                            ))}
                                        </ul>
                                    </CardText>
                                    <Button
                                    onClick={() => {
                                        setSelectedPizza(op);
                                        detailsToggle();
                                    }}>Edit Pizza</Button>
                                </CardBody>
                            </Card>
                        ))}
                </div>
                <FormGroup>
                    <Label htmlFor="employeeTaken">Taken By:</Label>
                    <Input 
                    style={{
                        width: '18rem'
                    }}
                    name="employeeTaken"
                    type="select"
                    bsSize="sm"
                    onChange={(e) => {
                        const copy = structuredClone(orderBuilder);
                        copy.employeeId = parseInt(e.target.value);
                        setOrderBuilder(copy);
                    }}>
                        {employees.map((e) => (
                            <option
                            value={e.id}
                            defaultValue={!!order.employeeId === e.id}
                            key={`employee--${e.id}`}
                            >{e.fullName}</option>
                        ))}
                    </Input>
                </FormGroup>
                <FormGroup className="editOrderType">
                    <Label className="orderType">Dine-In</Label>
                    <Input
                    className="orderTypeCheckbox"
                    type="checkbox"
                    checked={dineIn}
                    onChange={(e) => {
                        const { checked } = e.target;

                        if (checked) {
                            setDineIn(true);

                            setHasDriver(false);
                            setDriverId(null);
                        } else {
                            setDineIn(false);
                        }
                    }}/>
                    <Label className="orderType">Delivery</Label>
                    <Input 
                    className="orderTypeCheckbox"
                    type="checkbox"
                    checked={hasDriver}
                    onChange={(e) => {
                        const { checked } = e.target;

                        if (checked) {
                            setHasDriver(true);

                            setDineIn(false);
                            setTableNumber(null);
                        } else {
                            setHasDriver(false);
                        }
                    }}/>
                </FormGroup>
                {
                    dineIn
                    ?
                    <FormGroup>
                        <Label htmlFor="tableNumber">Table #:</Label>
                        <Input 
                        style={{
                            width: '18rem'
                        }}
                        name="tableNumber"
                        type="number"
                        bsSize="sm"
                        defaultValue={tableNumber}
                        onChange={(e) => {
                            setTableNumber(parseInt(e.target.value));
                        }}/>
                    </FormGroup>
                    :
                    ""
                }
                {
                    hasDriver
                    ?
                    <FormGroup>
                        <Label>Driven By:</Label>
                        <Input
                        style={{
                            width: '18rem'
                        }}
                        type="select"
                        bsSize="sm"
                        onChange={(e) => {
                            setDriverId(parseInt(e.target.value));
                        }}
                        >
                            {employees.map((e) => (
                                <option
                                value={e.id}
                                key={`employee--${e.id}`}>{e.fullName}</option>
                            ))}
                        </Input>
                    </FormGroup>
                    :
                    ""
                }
                <FormGroup>
                    <Label htmlFor="tip">Tip:</Label>
                    <InputGroup>
                        <InputGroupText>
                            $
                        </InputGroupText>
                        <input 
                        style={{
                            width: '18rem'
                        }}
                        name="tip"
                        type="number"
                        bssize="sm"
                        min="0.00"
                        step="0.01"
                        presicion={2}
                        value={tip}
                        onChange={(e) => {
                            setTip(parseFloat(e.target.value));
                        }}
                        />
                    </InputGroup>
                </FormGroup>
            </div>
            <Button 
            color="success"
            onClick={() => {
                handleOrderUpdate();
            }}
            >Save</Button>
            {
                detailsModal
                ?
                <Modal
                fullscreen
                size="xl"
                isOpen={detailsModal} toggle={detailsToggle}>
                    <ModalHeader toggle={detailsToggle}></ModalHeader>
                    <EditOrderPizzaModal 
                    pizzaObject={selectedPizza} 
                    toggle={detailsToggle}
                    setSelectedPizza={setSelectedPizza}
                    />
                </Modal>
                :
                ""
            }
        </div>
    )
}