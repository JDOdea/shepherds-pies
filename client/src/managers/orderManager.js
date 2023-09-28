const _apiUrl = "/api/order";

export const fetchOrders = () => {
    return fetch(_apiUrl).then((res) => res.json());
};

export const fetchNewestFirst = () => {
    return fetch(`${_apiUrl}/newest`).then((res) => res.json());
};

export const fetchOrder = (id) => {
    return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
};

export const postOrder = (order) => {
    return fetch(_apiUrl, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(order)
    }).then((res) => res.json());
};

export const putOrder = (id, order) => {
    return fetch(`${_apiUrl}/${id}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(order)
    });
}

export const deleteOrder = (id) => {
    return fetch(`${_apiUrl}/${id}`, {
        method: "DELETE"
    });
};