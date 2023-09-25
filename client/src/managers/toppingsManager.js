const _apiUrl = "/api/topping";

export const fetchToppings = () => {
    return fetch(_apiUrl).then((res) => res.json());
};

export const fetchToppingsForPizza = (pizzaId) => {
    return fetch(`${_apiUrl}/pizza${pizzaId}`).then((res) => res.json());
};