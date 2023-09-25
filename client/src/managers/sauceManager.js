const _apiUrl = "/api/sauce";

export const fetchSauces = () => {
    return fetch(_apiUrl).then((res) => res.json());
};

export const fetchSauce = (id) => {
    return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
};