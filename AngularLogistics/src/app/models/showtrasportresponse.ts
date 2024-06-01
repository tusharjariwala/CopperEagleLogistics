import { showtrasportdata } from "./showtrasportdata";

export interface showtrasportresponse {
    result: string;
    message: string;
    data: showtrasportdata[];
}