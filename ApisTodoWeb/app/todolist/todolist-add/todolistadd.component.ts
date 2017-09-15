import { Component} from '@angular/core';
import { TodoService } from '../services/services.component'
import { ITodoModel } from '../todolist-model/todomodel.component'

@Component({
    selector: 'todolist-add',
    templateUrl: './todolistadd.component.html'
})
export class TodoAddComponent {
    todoItem: ITodoModel;
    todoTitle: string

    constructor(private todoService: TodoService) {
    }


    submitForm(form: any): void {
        this.todoService.addTask(form.todotask);
        this.todoTitle = "";
        //    .subscribe(todo => {
        //    this.todoItem = todo;
        //    this.todoService.todoListChanged.next(this.todoItem);
        //});
    }
}
