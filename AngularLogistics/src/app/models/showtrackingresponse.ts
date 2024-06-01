import { showtrackingdata } from "./showtrackingdata";

export interface showtrackingresponse {
    result: string;
    message: string;
    data: showtrackingdata[];
}