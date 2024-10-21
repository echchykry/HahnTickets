import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { AppService } from './services/app.service';
import { Ticket } from './models/Ticket';
import { catchError, map, of } from 'rxjs';
import { CommonModule } from '@angular/common';
import { DialogModule } from 'primeng/dialog';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { InputTextModule } from 'primeng/inputtext';
import { DropdownModule } from 'primeng/dropdown';
import { HttpErrorResponse } from '@angular/common/http';
import { FormBuilder, FormControl, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { TicketToSave } from './models/TicketToSave';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { tick } from '@angular/core/testing';
import { PaginatorModule } from 'primeng/paginator';
import { TicketToUpdate } from './models/TicketToUpdate';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, TableModule,PaginatorModule,FormsModule , DropdownModule , ReactiveFormsModule, InputTextModule, InputTextareaModule, DialogModule, ButtonModule, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  statuses: any[] | undefined;
  TicketForm!: FormGroup;
  displayDialog: boolean = false;
  displayEditDialog: boolean = false;
  title = 'HahnTickets';
  tickets: Ticket[] = [];
  totalRecords: number = 1;
  hasPreviousPage: boolean = false;
  hasNextPage: boolean = false;
  pageIndex: number = 0;
  totalePages: number = 0;
  rows: number = 5;
  first: number = 0;
  isPaginatedLoading: boolean = false;
constructor(private appService: AppService, private fb: FormBuilder){

}

  ngOnInit(): void {
    this.TicketForm = this.fb.group({
      Description: new FormControl('', { validators: [Validators.required] }),
      Status: new FormControl('', { validators: [Validators.required] }),
    });

    this.appService.getTickets(this.first, this.rows)
    .pipe(
      map((data: any) => {
        this.tickets = data.items;
        this.pageIndex = data.pageIndex;
        this.totalRecords = data.count;
        this.rows = data.pageSize;
        console.log(this.totalRecords);

        return data.Items;
      }),
      catchError((err) => {
        return of([])
      })
    
    ).subscribe();

    this.statuses = [
      { name: 'Open', id: 1 },
      { name: 'Closed', id: 2 },

  ];
  }

  loadTickets(event: any){
    this.appService.getTickets(this.first, this.rows).subscribe(
      (data: any) => {
        this.tickets = data.Items;
        this.totalePages = data.TotalPages;
        this.pageIndex = data.PageIndex;
        this.totalRecords = data.Count;
        this.rows = data.PageSize;
        this.hasNextPage = data.HasNextPage;
        this.hasPreviousPage = data.HasPreviousPage;
        console.log(this.tickets);
      },
    );
  }
  showDialog(){
    this.displayDialog = true;
  }
  addNewTicket(){
    const ticket: TicketToSave = {
      statusId :this.TicketForm.get('Status')?.value.id,
      description : this.TicketForm.get('Description')?.value
    };
    this.appService.addTicket(ticket);
    this.TicketForm.reset();
    this.displayDialog = false
  }

  deleteTicket(id: string){
    this.appService.deleteTickets(id)
  }

  id:number | undefined =0;
  description: string | undefined = '';
  statusId: number = 0;
  showUpdateDialog(id: number){
    let ticket: Ticket | undefined = this.tickets.find(x => x.id === id); // can fetch it from the server
    this.id = ticket?.id;
    this.description = ticket?.description;

    this.statusId = this.statuses?.find(x => x.name === ticket?.status).id;

    this.displayEditDialog = true

  }
  updateTicket(){
    let ticket : TicketToUpdate = {
      id: this.id ?? 0,
      description: this.description ?? '',
      statusId: this.statusId
    }
    this.appService.updateTicket(ticket);
    this.displayEditDialog = false
  }

  onPageChange(event: any){
    this.first = event.first;
    this.rows = event.rows;
    this.appService.getTickets(this.first, this.rows)
    .pipe(
      map((data: any) => {
        this.tickets = data.items;
        this.pageIndex = data.pageIndex;
        this.totalRecords = data.count;
        this.rows = data.pageSize;
        console.log(this.totalRecords);

        return data.Items;
      }),
      catchError((err) => {
        return of([])
      })
    
    ).subscribe();
  }
  cancel(){
    this.displayDialog = false
  }
}
