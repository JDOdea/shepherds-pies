const _apiUrl = "/api/userProfile";

export const fetchAllUsers = () => {
    return fetch(_apiUrl).then((res) => res.json());
};