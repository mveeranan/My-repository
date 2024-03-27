import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class QuizService {

  //---------------properties---------------------

  qns : any[]=[];
  seconds :number=0;
  timer :any;
  qnProgress:number =0;
  correctAnswerCount: number = 0;

  readonly baseurl ="http://localhost:5139";

  //------------Hellper Methods-------------------

  displayTimeElapsed() {
    return Math.floor(this.seconds / 3600) + ':' + Math.floor(this.seconds / 60) + ':' + Math.floor(this.seconds % 60);
  }

  getParticipantName() {
    var participant = JSON.parse(localStorage.getItem('participant') || '{}');
    console.log("name ="+participant.name)
    return participant.name;
  }


  constructor( private http :HttpClient) { }

  //--------------Http Methods--------------------
  
  insertParticipant(name: string, email: string) {
    var body = {
      Name: name,
      Email: email
    }
    return this.http.post(this.baseurl + '/api/InsertParticipant', body);
  }

  getQuestions() {
    return this.http.get(this.baseurl + '/api/Questions');
  }

  getAnswers() {
    var body = this.qns.map(x => x.qnID);
    return this.http.post(this.baseurl + '/api/Answers', body);
  }

 
  submitScore() {
    var body = JSON.parse(localStorage.getItem('participant') ||'{}');
    body.Score = this.correctAnswerCount;
    body.TimeSpent = this.seconds;
    return this.http.post(this.baseurl + "/api/UpdateOutput", body);
  }
}
