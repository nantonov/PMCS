import { UserManagerSettings} from "oidc-client";

const authConfig: UserManagerSettings = {
    authority: 'https://localhost:5001',
    client_id: 'react-client-id',
    scope: 'openid profile email ScheduleAPI PetAPI',
    response_type: 'code',

    redirect_uri: 'http://localhost:3000/callback',
    post_logout_redirect_uri: 'http://localhost:3000/logout',
    silent_redirect_uri: `http://localhost:3000/refresh`,
    automaticSilentRenew: true,

    loadUserInfo: true,
    response_mode: 'query',
}

export default authConfig;