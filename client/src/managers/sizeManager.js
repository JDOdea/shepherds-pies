const _apiUrl = "/api/size";

export const fetchSizes = () => {
    return fetch(_apiUrl).then((res) => res.json());
};

export const fetchSize = (id) => {
    return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
}