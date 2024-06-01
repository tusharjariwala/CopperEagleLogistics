import { showorderdata } from "./showorderdata";

export interface showorderresponse {
    result: string;
    message: string;
    data: showorderdata[];
}