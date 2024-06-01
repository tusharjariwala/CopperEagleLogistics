import { showcitydata } from "./showcitydata";

export interface showcityresponse {
    result: string;
    message: string;
    data: showcitydata[];
}