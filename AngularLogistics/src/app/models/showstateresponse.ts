import { showstatedata } from "./showstatedata";

export interface showstateresponse {
    result: string;
    message: string;
    data: showstatedata[];
}