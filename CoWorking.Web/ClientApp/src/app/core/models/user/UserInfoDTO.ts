import { AuthorizationRoles } from "src/app/configs/authorization-roles";

export class UserInfoDTO {
    id: string;
    name: string;
    surname: string;
    userName: string;
    email: string;
    role: AuthorizationRoles;
}
