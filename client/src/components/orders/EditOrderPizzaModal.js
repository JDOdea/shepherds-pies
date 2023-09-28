import React, { useEffect, useState } from "react";
import { fetchSizes } from "../../managers/sizeManager";
import { fetchCheeses } from "../../managers/cheeseManager";
import { fetchSauces } from "../../managers/sauceManager";
import { fetchToppings } from "../../managers/toppingsManager";
import { Button, Form, FormGroup, Input, Label, ModalBody, ModalFooter } from "reactstrap";

export const EditOrderPizzaModal = ({ pizzaObject, toggle, setSelectedPizza }) => {
    const [sizes, setSizes] = useState([]);
    const [cheeses, setCheeses] = useState([]);
    const [sauces, setSauces] = useState([]);
    const [toppings, setToppings] = useState([]);
    const [toppingIds, setToppingIds] = useState([]);
    const [pizzaToppings, setPizzaToppings] = useState([]);
    const [toppingsBuilder, setToppingsBuilder] = useState([]);
    const [pizzaBuilder, setPizzaBuilder] = useState({
        sizeId: 0,
        size: null,
        cheeseId: 0,
        cheese: null,
        sauceId: 0,
        sauce: null,
    });

    const handleToppingCheck = (e, id) => {
        const { checked } = e.target;
        let clone = structuredClone(toppingIds);

        if (checked) {
            clone.push(id);

            const ptClone = structuredClone(toppingsBuilder.filter(pt => {
                return pt.toppingId !== id;
            }));

            const newPizzaTopping = {
                pizzaId: pizzaObject.id,
                toppingId: id,
                topping: toppings.find((topping) => topping.id === id),
                quantity: 1
            }
            ptClone.push(newPizzaTopping);
            setToppingsBuilder(ptClone);
        } else {
            setToppingsBuilder(structuredClone(toppingsBuilder.filter(pt => {
                return pt.toppingId !== id;
            })))
            clone = toppingIds.filter((ti) => ti !== id);
        }
        setToppingIds(clone);
    }

    const handleToppingCount = (t) => {
        const foundPizzaTopping = pizzaToppings.find((topping) => {
            return topping.toppingId === t.id;
        })

        if (!foundPizzaTopping) {
            return 1;
        }

        return foundPizzaTopping.quantity;
    }

    const handlePizzaTopping = (e, t) => {
        const clone = structuredClone(toppingsBuilder.filter(pt => {
            return pt.toppingId !== t.id;
        }));

        const newPizzaTopping = {
            pizzaId: pizzaObject.id,
            toppingId: t.id,
            topping: toppings.find((topping) => topping.id === t.id),
            quantity: parseInt(e.target.value)
        };

        if (!newPizzaTopping.quantity) {
            newPizzaTopping.quantity = 1;
        }

        clone.push(newPizzaTopping);
        setToppingsBuilder(clone);
    }

    const handleSavePizza = () => {
        const clone = structuredClone(pizzaBuilder);
        clone.pizzaToppings = toppingsBuilder;
        setSelectedPizza(clone);
        toggle();
    }


    useEffect(() => {
        fetchSizes().then(setSizes);
        fetchCheeses().then(setCheeses);
        fetchSauces().then(setSauces);
        fetchToppings().then(setToppings);

        setPizzaBuilder(pizzaObject);
        setToppingsBuilder(pizzaObject.pizzaToppings);
        setPizzaToppings(pizzaObject.pizzaToppings);
        setToppingIds(pizzaObject.pizzaToppings.map((pt) => {
            return pt.toppingId;
        }))
    }, []);


    if (!pizzaObject) {
        return null;
    }

    return (
        <>
            <ModalBody>
            <Form className="editOrderForm">
                    <div className="editOrderSelectors">
                        <FormGroup>
                            <Label>Size:</Label>
                            {sizes.map((s) => (
                                <div key={`size--${s.id}`}>
                                    <Label className="editOrderType">{s.name}({s.length})</Label>
                                    <Input 
                                    className="editOrderTypeCheckbox"
                                    type="checkbox"
                                    id={s.id}
                                    checked={pizzaBuilder.sizeId === s.id}
                                    onChange={() => {
                                        const copy = structuredClone(pizzaBuilder);
                                        copy.sizeId = s.id;
                                        copy.size = sizes.find((si) => {
                                            return si.id === s.id;
                                        })

                                        setPizzaBuilder(copy);
                                    }}/>
                                </div>
                            ))}
                        </FormGroup>
                        <FormGroup>
                            <Label>Cheese:</Label>
                            {cheeses.map((c) => (
                                <div key={`cheese--${c.id}`}>
                                    <Label className="editOrderType">{c.type}</Label>
                                    <Input 
                                    className="editOrderTypeCheckbox"
                                    type="checkbox"
                                    id={c.id}
                                    checked={pizzaBuilder.cheeseId === c.id}
                                    onChange={() => {
                                        const copy = structuredClone(pizzaBuilder);
                                        copy.cheeseId = c.id;
                                        copy.cheese = cheeses.find((ci) => {
                                            return ci.id === c.id;
                                        })

                                        setPizzaBuilder(copy);
                                    }}/>
                                </div>
                            ))}
                        </FormGroup>
                        <FormGroup>
                            <Label>Sauce:</Label>
                            {sauces.map((s) => (
                                <div key={`sauce--${s.id}`}>
                                    <Label className="editOrderType">{s.type}</Label>
                                    <Input 
                                    className="editOrderTypeCheckbox"
                                    type="checkbox"
                                    id={s.id}
                                    checked={pizzaBuilder.sauceId === s.id}
                                    onChange={() => {
                                        const copy = structuredClone(pizzaBuilder);
                                        copy.sauceId = s.id;
                                        copy.sauce = sauces.find((si) => {
                                            return si.id === s.id;
                                        })

                                        setPizzaBuilder(copy);
                                    }}/>
                                </div>
                            ))}
                        </FormGroup>
                    </div>
                    <FormGroup>
                        <Label>Toppings <br />{`($0.50 each)`}:</Label>
                        <div className="editOrderToppings">
                            {toppings.map((t) => (
                                <div className="editOrderTopping" key={`topping--${t.id}`}>
                                    <Label className="editOrderType">{t.name}</Label>
                                    <Input 
                                    className="editOrderTypeCheckbox"
                                    type="checkbox"
                                    checked={!!toppingsBuilder.find((ti) => {
                                        return ti.toppingId === t.id;
                                    })}
                                    onChange={(e) => {
                                        handleToppingCheck(e, t.id);
                                    }}/>
                                    {
                                        toppingIds.find((ti) => t.id === ti)
                                        ?
                                        <React.Fragment>
                                            <Input
                                                className="editOrderToppingAmount"
                                                style={{width: 50}}
                                                type="number"
                                                min={1}
                                                defaultValue={handleToppingCount(t)}
                                                onChange={(e) => {
                                                    handlePizzaTopping(e, t);
                                                }}
                                                />
                                        </React.Fragment>
                                        :
                                        ""
                                    }
                                </div>
                            ))}
                        </div>
                    </FormGroup>
                </Form>
            </ModalBody>
            <ModalFooter>
                <Button
                color="success"
                onClick={() => {
                    handleSavePizza();
                }}>
                    Save
                </Button>
            </ModalFooter>
        </>
    )
}