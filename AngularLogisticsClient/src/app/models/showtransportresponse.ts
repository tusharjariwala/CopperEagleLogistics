import { showtransportdata } from "./showtransportdata";

export interface showtransportresponse {
    result: string;
    message: string;
    data: showtransportdata[];
}