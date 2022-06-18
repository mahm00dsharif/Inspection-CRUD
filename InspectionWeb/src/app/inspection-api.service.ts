import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, throwError } from 'rxjs';
import { Observable } from 'rxjs/internal/Observable';
import { Inspection } from './Models/Inspection.class';
import { InspectionType } from './Models/InspectionType.class';
import { Status } from './Models/Status.class';

@Injectable({
  providedIn: 'root'
})
export class InspectionApiService {

  inspectionApiUrl: string = 'https://localhost:7280/Inspections';
  inspectionTypeApiUrl: string = 'https://localhost:7280/InspectionTypes';
  statusApiUrl: string = 'https://localhost:7280/Status';
  constructor(private httpClient: HttpClient) {
    
   }

   GetInspectionsList():Observable<Inspection[]> {
      return this.httpClient.get<Inspection[]>(this.inspectionApiUrl).pipe(
        catchError(this.handleError)
      );
   }

  GetInspection(id:number):Observable<Inspection>{
    return this.httpClient.get<Inspection>(this.inspectionApiUrl + "/" + id).pipe(
      catchError(this.handleError)
    )
  }   

  AddInspection(inspectionName:string):Observable<Inspection>{
    return this.httpClient.post<Inspection>(this.inspectionApiUrl,inspectionName).pipe(
      catchError(this.handleError)
    )
  }

  UpdateInspection(inspectionName: string):Observable<Inspection>{
    return this.httpClient.put<Inspection>(this.inspectionApiUrl,inspectionName).pipe(
      catchError(this.handleError)
    )
  }

  DeleteInspection(id: number): Observable<{}>{
    return this.httpClient.delete<{}>(this.inspectionApiUrl +"/"+id).pipe(
      catchError(this.handleError)
    )
  }


//Inspection Types
  GetInspectionTypesList():Observable<InspectionType[]> {
    return this.httpClient.get<InspectionType[]>(this.inspectionTypeApiUrl).pipe(
      catchError(this.handleError)
    );
 }

GetInspectionType(id:number):Observable<InspectionType>{
  return this.httpClient.get<InspectionType>(this.inspectionTypeApiUrl + "/" + id).pipe(
    catchError(this.handleError)
  )
}   

AddInspectionType(inspectionName:string):Observable<InspectionType>{
  return this.httpClient.post<InspectionType>(this.inspectionTypeApiUrl,inspectionName).pipe(
    catchError(this.handleError)
  )
}

UpdateInspectionType(inspectionName: string):Observable<InspectionType>{
  return this.httpClient.put<InspectionType>(this.inspectionTypeApiUrl,inspectionName).pipe(
    catchError(this.handleError)
  )
}

DeleteInspectionType(id: number): Observable<{}>{
  return this.httpClient.delete<{}>(this.inspectionTypeApiUrl +"/"+id).pipe(
    catchError(this.handleError)
  )
}


//Status api methods
GetStatusList():Observable<Status[]> {
  return this.httpClient.get<Status[]>(this.statusApiUrl).pipe(
    catchError(this.handleError)
  );
}

GetStatus(id:number):Observable<Status>{
return this.httpClient.get<Status>(this.statusApiUrl + "/" + id).pipe(
  catchError(this.handleError)
)
}   

AddStatus(inspectionName:string):Observable<Status>{
return this.httpClient.post<Status>(this.statusApiUrl,inspectionName).pipe(
  catchError(this.handleError)
)
}

UpdateStatus(inspectionName: string):Observable<Status>{
return this.httpClient.put<Status>(this.statusApiUrl,inspectionName).pipe(
  catchError(this.handleError)
)
}

DeleteStatus(id: number): Observable<{}>{
return this.httpClient.delete<{}>(this.statusApiUrl +"/"+id).pipe(
  catchError(this.handleError)
)
}

   private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
        console.error('An error occurred:', error.error.message);
    } else {
        console.error(
            `Backend returned code ${error.status}, ` +
            `body was: ${error.error}`);
    }
    return throwError(() => 'Something bad happened; please try again later.');
  }
}
