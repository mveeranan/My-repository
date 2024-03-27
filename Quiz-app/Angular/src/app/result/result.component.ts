import { Component, OnInit } from '@angular/core';
import { QuizService } from '../Shared/quiz.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-result',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.css']
})
export class ResultComponent implements OnInit {

  constructor(public db:QuizService,private router:Router) { }

  ngOnInit(): void {
    this.db.getAnswers().subscribe(
      (data: any) => {
        this.db.correctAnswerCount = 0;
        this.db.qns.forEach((e, i) => {
          if (e.answer == data[i])
            this.db.correctAnswerCount++;
          e.correct = data[i];
        });
      }
    );
  }
  

  OnSubmit() {
    this.db.submitScore().subscribe(() => {
      this.restart();
    });
  }

  restart() {
    localStorage.setItem('qnProgress', "0");
    localStorage.setItem('qns', "");
    localStorage.setItem('seconds', "0");
    this.router.navigate(['/quiz']);
  }
}
