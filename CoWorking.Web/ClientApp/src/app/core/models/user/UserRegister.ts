import { AuthorizationRoles } from "src/app/configs/authorization-roles";

export class UserRegister {
    name: string;
    surname: string;
    userName: string;
    email: string;
    role: AuthorizationRoles;
    password: string;
}
