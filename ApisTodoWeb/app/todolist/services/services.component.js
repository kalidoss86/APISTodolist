"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var http_1 = require("@angular/http");
require("rxjs/Rx");
var Subject_1 = require("rxjs/Subject");
require("rxjs/add/operator/map");
var TodoService = (function () {
    function TodoService(http) {
        var _this = this;
        this.http = http;
        this.todoListChanged = new Subject_1.Subject();
        this.todoList = [];
        this.todoListUrl = "http://localhost:63507/Home/";
        this.headers = new http_1.Headers({
            'Content-Type': 'application/json',
            'Accept': 'q=0.8;application/json;q=0.9'
        });
        this.options = new http_1.RequestOptions({ headers: this.headers });
        this.getApp().subscribe(function (tList) {
            _this.todoList = tList;
            _this.todoListChanged.next(_this.todoList);
        });
    }
    TodoService.prototype.getApp = function () {
        return this.http.get(this.todoListUrl + "GetTodoList")
            .map(this.todoListAll);
    };
    TodoService.prototype.todoListAll = function (response) {
        return response.json();
    };
    TodoService.prototype.toTodo = function (r) {
        var todo = ({
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
    };
    TodoService.prototype.addTask = function (task) {
        var _this = this;
        var data = JSON.stringify({ task: task });
        this.http.post(this.todoListUrl + "Addtask", data, this.options)
            .map(function (res) { return res.json(); })
            .subscribe(function (todo) {
            console.log("Add task");
            console.log(todo);
            _this.todoList.push(todo);
            _this.todoListChanged.next(_this.todoList);
        });
        //.map((data: Response) => {
        //    console.log("Add Task return");
        //    console.log(data.json());
        //    this.todoList.push(data.json() as ITodoModel);
        //});
        //console.log("todolistchanged event fired...");
        //console.log(this.todoList);
        //this.todoListChanged.next(this.todoList);
    };
    return TodoService;
}());
TodoService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], TodoService);
exports.TodoService = TodoService;
//# sourceMappingURL=services.component.js.map