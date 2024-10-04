import { NgFor } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NgFor],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent implements OnInit {
  http = inject(HttpClient);
  title = 'To Do App';
  taskLists: any;

  ngOnInit(): void {
    // No need to unsubscribe from this, http requests always complete and will not hang around in memory.
    this.http.get('https://localhost:7285/api/List/GetLists').subscribe({
      next: (response) => (this.taskLists = response),
      error: (error) => console.log(error),
      complete: () => {
        console.log('Task complete');
        console.log(this.taskLists);
      },
    });
  }
}
