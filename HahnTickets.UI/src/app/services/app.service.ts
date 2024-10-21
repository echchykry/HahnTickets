import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, Subscription } from "rxjs";
import { TicketToSave } from "../models/TicketToSave";
import { TicketToUpdate } from "../models/TicketToUpdate";




@Injectable({
    providedIn: 'root'
  })

export class AppService  {
  private addSubscription?: Subscription;
    constructor(private http:HttpClient) { }


    getTickets(first: number, pageSize: number): Observable<any>{
        return this.http.get<any>(`https://localhost:7183/Ticket/GetAll${0}?&pageIndex=${first}&pageSize=${pageSize}`);
    }
    deleteTickets(id : string) {
         this.http.delete(`https://localhost:7183/Ticket/${id}`).subscribe({
            complete: () =>{
              alert("Successfully deleted");
            },
            error: (error: HttpErrorResponse) => {
              alert(error.error.title);

            }
          });;
    }

    addTicket(ticket: TicketToSave) {
    this.addSubscription = this.http.post<any>('https://localhost:7183/Ticket/addTicket', ticket).subscribe({
        complete: () =>{
          alert("Successfully added")
        },
        error: (error: HttpErrorResponse) => {
          alert(error);
          console.log(error);
        }
      });
    }

    updateTicket(ticket: TicketToUpdate) {
      this.addSubscription = this.http.put<any>('https://localhost:7183/Ticket', ticket).subscribe({
          complete: () =>{
            alert("Successfully updated")
          },
          error: (error: HttpErrorResponse) => {
            alert(error);
            alert("error occured")
            console.log(error);
          }
        });
      }
}