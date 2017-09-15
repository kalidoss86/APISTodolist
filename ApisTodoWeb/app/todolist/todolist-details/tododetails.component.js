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
var services_component_1 = require("../services/services.component");
var TodoDetailsComponent = (function () {
    function TodoDetailsComponent(todoService) {
        this.todoService = todoService;
        this.loading = true;
        //todoService.getApp().subscribe((list: ITodoModel[]) => {
        //    this.todoList = list;
        //});
        ////this.todoList = todoService.getApp();
        //console.log(this.todoList);
        //this.loading = false;
    }
    TodoDetailsComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.subscription = this.todoService.todoListChanged
            .subscribe(function (tlist) {
            _this.todoList = tlist;
            console.log("todo details event handler");
            console.log(_this.todoList);
            _this.loading = false;
        });
        console.log("Subscribed...");
    };
    TodoDetailsComponent.prototype.ngOnDestroy = function () {
        this.subscription.unsubscribe();
    };
    return TodoDetailsComponent;
}());
TodoDetailsComponent = __decorate([
    core_1.Component({
        selector: 'todolist-detail',
        //template: '{{todoList | json}}'
        templateUrl: './tododetails.component.html'
    }),
    __metadata("design:paramtypes", [services_component_1.TodoService])
], TodoDetailsComponent);
exports.TodoDetailsComponent = TodoDetailsComponent;
//# sourceMappingURL=tododetails.component.js.map