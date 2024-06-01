import { showemployeedata } from "./showemployeedata";

export interface showemployeeresponse {
    result: string;
    message: string;
    data: showemployeedata[];
}