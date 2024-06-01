import { showauthdata } from "./showauthdata";

export interface showauthresponse {
    result: string;
    message: string;
    data: showauthdata[];
}
