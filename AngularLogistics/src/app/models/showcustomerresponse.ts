import { showcustomerdata } from "./showcustomerdata";

export interface showcustomerresponse {
    result: string;
    message: string;
    data: showcustomerdata[];
}