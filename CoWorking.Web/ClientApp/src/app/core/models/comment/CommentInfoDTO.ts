import { UserCommentInfoDTO } from "../user/UserCommentInfoDTO";

export class CommentInfoDTO {
    text: string;
    dateOfCreate: Date;
    user: UserCommentInfoDTO;
}
