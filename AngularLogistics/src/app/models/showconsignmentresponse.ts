import { showconsignmentdata } from "./showconsignmentdata";

export interface showconsignmentresponse {
    result: string;
    message: string;
    data: showconsignmentdata[];
}