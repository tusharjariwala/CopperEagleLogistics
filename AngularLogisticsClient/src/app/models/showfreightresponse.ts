import { showfreightdata } from "./showfreightdata";

export interface showfreightresponse {
    result: string;
    message: string;
    data: showfreightdata[];
}