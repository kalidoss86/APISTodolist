import { Component, OnInit, OnDestroy } from '@angular/core'

import { TodoService } from '../services/services.component'
import { ITodoModel } from '../todolist-model/todomodel.component'
import { Subscription } from 'rxjs/Subscription';


@Component({
    selector: 'todolist-detail',
    //template: '{{todoList | json}}'
    templateUrl: './tododetails.component.html'
})
export class TodoDetailsComponent implements OnInit, OnDestroy {
    todoList: ITodoModel[];
    subscription: Subscription;
    loading: boolean;
    constructor(private todoService: TodoService) {
        this.loading = true;
        //todoService.getApp().subscribe((list: ITodoModel[]) => {
        //    this.todoList = list;
        //});
        ////this.todoList = todoService.getApp();
        //console.log(this.todoList);
        //this.loading = false;
    }

    ngOnInit() {
        this.subscription = this.todoService.todoListChanged
            .subscribe(
            (tlist: ITodoModel[]) => {
                this.todoList = tlist;
                console.log("todo details event handler");
                console.log(this.todoList);
                this.loading = false;
            });
        console.log("Subscribed...");
    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }
}
