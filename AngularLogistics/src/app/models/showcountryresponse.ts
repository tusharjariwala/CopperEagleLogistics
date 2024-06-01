import { showcountrydata } from "./showcountrydata";

export interface showcountryresponse {
    result: string;
    message: string;
    data: showcountrydata[];
}