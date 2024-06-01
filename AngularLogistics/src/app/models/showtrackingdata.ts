import { showconsignmentdata } from "./showconsignmentdata";
import { showarehousedata } from "./showwarehousedata";

export class showtrackingdata {
    tracking_id_pk= 0;
    tracking_date_and_time= "";
    consignment_id_fk= 0;
    consignment_number= "";
    deliver_date= "";
    sender_address= "";
    receiver_address= "";
    receiver_person= "";
    remark= "";
    warehouse_id_fk1= 0;
    warehouse_name1= "";
    address1= "";
    contactperson_name= "";
    contactperson_number= "";
    status= 1;
    added_by=0;
}
