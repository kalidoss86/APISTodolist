import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


import { AppComponent } from './app.component';
import {TodoService } from './todolist/services/services.component'
import { TodoDetailsComponent } from './todolist/todolist-details/tododetails.component'
import { ITodoModel } from './todolist/todolist-model/todomodel.component'
import { TodoAddComponent } from './todolist/todolist-add/todolistadd.component'


@NgModule({
  imports:      [ BrowserModule, HttpModule, FormsModule, ReactiveFormsModule ],
  declarations: [ AppComponent, TodoDetailsComponent, TodoAddComponent ],
  bootstrap: [AppComponent, TodoDetailsComponent],
  providers : [TodoService]
})
export class AppModule { }
