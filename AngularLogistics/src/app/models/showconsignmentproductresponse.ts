import { showconsignmentproductdata } from "./showconsignmentproductdata";

export interface showconsignmentproductresponse {
    result: string;
    message: string;
    data: showconsignmentproductdata[];
}