import { Component, OnInit } from '@angular/core';
import { QuizService } from '../Shared/quiz.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.css']
})
export class QuizComponent implements OnInit {

  constructor(public db:QuizService,private router : Router) { }

  ngOnInit(): void {

    this.db.seconds =0;
    this.db.qnProgress =0;
    this.db.getQuestions().subscribe((
      (data : any) => {
        this.db.qns =data;
        console.log(data);
        this.startTimer();
      }      
    ));
  }

    startTimer() {
        this.db.timer = setInterval(() => {
          this.db.seconds++;
        }, 1000);
      }

      Answer(qID :number, choice:number) {
       
        this.db.qns[this.db.qnProgress].answer = choice;
        localStorage.setItem('qns', JSON.stringify(this.db.qns));
        this.db.qnProgress++;
        localStorage.setItem('qnProgress', this.db.qnProgress.toString());
        if (this.db.qnProgress == 10) {
          clearInterval(this.db.timer);
          this.router.navigate(['/result']);
        }
  }  
}