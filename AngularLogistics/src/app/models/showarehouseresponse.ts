import { showarehousedata } from "./showwarehousedata";

export interface showarehouseresponse {
    result: string;
    message: string;
    data: showarehousedata[];
}