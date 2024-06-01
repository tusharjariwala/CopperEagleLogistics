import { showvehicledata } from "./showvehicledata";

export interface showvehicleresponse {
    result: string;
    message: string;
    data: showvehicledata[];
}