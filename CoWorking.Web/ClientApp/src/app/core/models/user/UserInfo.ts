import { AuthorizationRoles } from "src/app/configs/authorization-roles";

export class UserInfo {
    id: string;
    username: string;
    role: string;
    isAuth: boolean = false;
}
