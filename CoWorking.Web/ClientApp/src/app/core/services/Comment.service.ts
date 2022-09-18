import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { addCommentUrl } from 'src/app/configs/api-endpoints';
import { AddCommentDTO } from '../models/comment/AddCommentDTO';
import { CommentInfoDTO } from '../models/comment/CommentInfoDTO';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  private httpOption = {
    headers: new HttpHeaders({
        Authorization: 'Bearer ' + this.getToken()
    })
  };

  private getToken(): any{
    return localStorage.getItem('token')?.toString();
  }

  constructor(private http: HttpClient) { }

  addComment(comment: AddCommentDTO) : Observable<CommentInfoDTO> {
    return this.http.post<CommentInfoDTO>(addCommentUrl, comment, this.httpOption);
  }

}
