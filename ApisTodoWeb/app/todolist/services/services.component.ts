import { Injectable } from '@angular/core'
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import 'rxjs/Rx';
import { Observable } from "rxjs/Observable";
import { Subject } from 'rxjs/Subject';
import 'rxjs/add/operator/map';

import { ITodoModel } from '../todolist-model/todomodel.component';

@Injectable()
export class TodoService {
    headers: Headers;
    options: RequestOptions;
    todoListChanged = new Subject<ITodoModel[]>();
    todoList: ITodoModel[] = []

    constructor(private http: Http) {
        this.headers = new Headers({
            'Content-Type': 'application/json',
            'Accept': 'q=0.8;application/json;q=0.9'
        });
        this.options = new RequestOptions({ headers: this.headers });
        this.getApp().subscribe(tList => {
            this.todoList = tList;
            this.todoListChanged.next(this.todoList);
        });
    }

    private todoListUrl = "http://localhost:63507/Home/";


    getApp(): Observable<ITodoModel[]> {
        return this.http.get(this.todoListUrl + "GetTodoList")
            .map(this.todoListAll);
    }

    todoListAll(response: Response): ITodoModel[] {
        return response.json();
    }

    toTodo(r: any): ITodoModel {
        let todo = <ITodoModel>({
            todoId: r.TodoId,
            todoTitle: r.TodoTitle,
            todoDescription: r.TodoDescrption,
            isCompleted: r.IsCompleted,
            completedTime: r.CompletedTime,
            createDate: r.CreateTime,
            dueDate: r.DueDate,
            isDeleted: r.IsDeleted,
            updateTime: r.UpdateTime
        });
        return todo;
    }

    addTask(task: any)  {
        let data = JSON.stringify({ task: task });
         this.http.post(this.todoListUrl + "Addtask", data, this.options)
            .map((res: Response) => res.json())
            .subscribe(todo => {
                console.log("Add task");
                console.log(todo);
                this.todoList.push(todo);
                this.todoListChanged.next(this.todoList);
            });
        //.map((data: Response) => {
        //    console.log("Add Task return");
        //    console.log(data.json());
        //    this.todoList.push(data.json() as ITodoModel);
        //});
        //console.log("todolistchanged event fired...");
        //console.log(this.todoList);
        //this.todoListChanged.next(this.todoList);
    }


}
