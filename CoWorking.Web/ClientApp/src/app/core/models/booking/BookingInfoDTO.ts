import { UserInfoDTO } from "../user/UserInfoDTO";

export class BookingInfoDTO {
    id: number;
    name: string;
    description: string;
    dateStart: Date;
    dateEnd: Date;
    user: UserInfoDTO;
}