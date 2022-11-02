type AxiosConfig = {
    baseURL: string;
    AccessControlAllowOrigin : string;
    AccessControlAllowMethods : string;
}

export const axiosConfig : AxiosConfig = {
    baseURL: 'https://localhost:7045',
    AccessControlAllowOrigin: '*',
    AccessControlAllowMethods: 'GET,PUT,POST,DELETE,PATCH,OPTIONS',
};