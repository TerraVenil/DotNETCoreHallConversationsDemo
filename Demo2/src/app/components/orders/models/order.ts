export interface Order {
    number: string;
    orderTypeId: number;
    orderTypeName: string;
    status: string;
    comment: string;
    callMasterTime: Date;
    deadlineTime: Date;
    price: number;
    prepaidExpense: number;
    isUrgently: boolean;
}