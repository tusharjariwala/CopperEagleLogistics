import { showdriverdata } from "./showdriverdata";

export interface showdriverresponse {
    result: string;
    message: string;
    data: showdriverdata[];
}