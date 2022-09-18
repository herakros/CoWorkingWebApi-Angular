import { CommentInfoDTO } from "../comment/CommentInfoDTO";
import { UserBookingInfoDTO } from "../user/UserBookingInfoDTO";
export class BookingInfoDTO {
    id: number;
    name: string;
    description: string;
    dateStart: Date;
    dateEnd: Date;
    user: UserBookingInfoDTO;
    comments: CommentInfoDTO[];
}
