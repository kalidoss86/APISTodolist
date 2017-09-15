export interface ITodoModel {
    todoId: string,
    todoTitle: string,
    todoDescription: string,
    isCompleted: boolean,
    isDeleted: boolean,
    createDate: Date,
    dueDate: Date,
    updateTime: Date,
    completedTime: Date
}
