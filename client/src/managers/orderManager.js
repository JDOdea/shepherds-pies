const _apiUrl = "/api/order";

export const fetchOrders = () => {
    return fetch(_apiUrl).then((res) => res.json());
};

export const fetchNewestFirst = () => {
    return fetch(`${_apiUrl}/newest`).then((res) => res.json());
}