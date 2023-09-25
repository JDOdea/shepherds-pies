const _apiUrl = "/api/cheese";

export const fetchCheeses = () => {
    return fetch(_apiUrl).then((res) => res.json());
};

export const fetchCheese = (id) => {
    return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
};